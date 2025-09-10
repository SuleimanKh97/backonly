using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using LibraryManagementAPI.Data;
using LibraryManagementAPI.Models;
using LibraryManagementAPI.Services;
using LibraryManagementAPI.Converters;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using CloudinaryDotNet;

var builder = WebApplication.CreateBuilder(args);

// Configure web root path for static files
if (string.IsNullOrEmpty(builder.Environment.WebRootPath))
{
    builder.Environment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
}

// Ensure uploads directory exists
var uploadsPath = Path.Combine(builder.Environment.WebRootPath, "uploads", "products");
if (!Directory.Exists(uploadsPath))
{
    Directory.CreateDirectory(uploadsPath);
}

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

// Configure Entity Framework with PostgreSQL DateTime handling
builder.Services.AddDbContext<LibraryDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        npgsqlOptions => npgsqlOptions
            .EnableRetryOnFailure(3, TimeSpan.FromSeconds(10), null)
    );

    // Configure DateTime handling for PostgreSQL compatibility
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
});


// Configure Identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings
    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<LibraryDbContext>()
.AddDefaultTokenProviders();

// Configure JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!)),
        ClockSkew = TimeSpan.Zero
    };
});

// Add Authorization
builder.Services.AddAuthorization();

// Configure DateTime to use Gregorian calendar
System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("en-US");
System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo("en-US");

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins(
                "https://frontendonly.vercel.app",
                "https://royal-library.vercel.app",
                "http://localhost:5173",
                "http://localhost:3000",
                "http://localhost:4200",
                "https://localhost:4200",
                "http://localhost:5000",
                "https://localhost:5000",
                "http://127.0.0.1:5173",
                "http://127.0.0.1:3000",
                "http://127.0.0.1:4200",
                "https://127.0.0.1:4200"
              )
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials()
              .WithExposedHeaders("Content-Disposition");
    });
    
    // Specific policy for production
    options.AddPolicy("Production", policy =>
    {
        policy.WithOrigins(
                "https://frontendonly.vercel.app",
                "https://royal-library.vercel.app",
                "http://localhost:5173",
                "http://localhost:3000",
                "http://localhost:4200",
                "https://localhost:4200"
              )
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials()
              .WithExposedHeaders("Content-Disposition");
    });
    
    // Fallback policy that allows specific origins for debugging
    options.AddPolicy("Debug", policy =>
    {
        policy.WithOrigins(
                "https://frontendonly.vercel.app",
                "https://royal-library.vercel.app",
                "http://localhost:5173",
                "http://localhost:3000",
                "http://localhost:4200",
                "https://localhost:4200",
                "http://localhost:5000",
                "https://localhost:5000",
                "http://127.0.0.1:5173",
                "http://127.0.0.1:3000",
                "http://127.0.0.1:4200",
                "https://127.0.0.1:4200"
              )
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials()
              .WithExposedHeaders("Content-Disposition");
    });
});

// Register services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<IBookInquiryService, BookInquiryService>();
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IStudyMaterialService, StudyMaterialService>();
builder.Services.AddScoped<IStudyTipService, StudyTipService>();
builder.Services.AddScoped<IStudyScheduleService, StudyScheduleService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Library Management API",
        Version = "v1",
        Description = "API for managing library books and customer inquiries"
    });

    // Add JWT authentication to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Configure Cloudinary
var cloudName = builder.Configuration["Cloudinary:CloudName"];
var apiKey = builder.Configuration["Cloudinary:ApiKey"];
var apiSecret = builder.Configuration["Cloudinary:ApiSecret"];

if (string.IsNullOrEmpty(cloudName) || string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(apiSecret))
{
    throw new InvalidOperationException("Cloudinary configuration is missing. Please set Cloudinary:CloudName, Cloudinary:ApiKey, and Cloudinary:ApiSecret in appsettings.json or environment variables.");
}

var cloudinaryAccount = new Account(cloudName, apiKey, apiSecret);
var cloudinary = new Cloudinary(cloudinaryAccount);
builder.Services.AddSingleton(cloudinary);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library Management API V1");
    c.RoutePrefix = "swagger"; // Set Swagger UI at /swagger
});

app.UseHttpsRedirection();

// Configure static files for uploads directory specifically
// This must come BEFORE app.UseStaticFiles() to take precedence
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.WebRootPath, "uploads")),
    RequestPath = "/uploads"
});

// Use Static Files for serving other static files
app.UseStaticFiles();

// Log the web root path for debugging
var startupLogger = app.Services.GetRequiredService<ILogger<Program>>();
startupLogger.LogInformation("WebRootPath: {WebRootPath}", builder.Environment.WebRootPath);
startupLogger.LogInformation("Uploads path: {UploadsPath}", Path.Combine(builder.Environment.WebRootPath, "uploads"));
startupLogger.LogInformation("Products path: {ProductsPath}", Path.Combine(builder.Environment.WebRootPath, "uploads", "products"));

// Use CORS - Must be before UseAuthentication and UseAuthorization
// Temporarily use AllowAll for production to fix CORS issues
var corsPolicy = "AllowAll"; // app.Environment.IsDevelopment() ? "AllowAll" : "Production";
app.UseCors(corsPolicy);

// Log CORS policy being used
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Using CORS policy: {CorsPolicy} for environment: {Environment}", corsPolicy, app.Environment.EnvironmentName);

// Add CORS debugging middleware
app.Use(async (context, next) =>
{
    // Log preflight requests
    if (context.Request.Method == "OPTIONS")
    {
        logger.LogInformation("CORS Preflight request from: {Origin} to {Path}", context.Request.Headers["Origin"], context.Request.Path);
    }

    await next();

    // Log CORS headers in response
    if (context.Response.Headers.ContainsKey("Access-Control-Allow-Origin"))
    {
        logger.LogInformation("CORS Response headers applied for {Path}", context.Request.Path);
    }
});

// Use Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// Add migration endpoint for manual migration
app.MapPost("/api/admin/migrate", async (LibraryDbContext context, ILogger<Program> logger) =>
{
    try
    {
        logger.LogInformation("🔧 Manual migration endpoint called");

        // First try EF migration
        try
        {
            await context.Database.MigrateAsync();
            logger.LogInformation("✅ EF migration completed successfully");
        }
        catch (Exception efEx)
        {
            logger.LogWarning(efEx, "EF migration failed, trying manual SQL migration");

            // Fallback to manual SQL migration
            await ExecuteManualMigrationAsync(context, logger);
        }

        return Results.Ok(new {
            message = "Migration completed successfully",
            timestamp = DateTime.UtcNow,
            method = "EF + Manual SQL"
        });
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Manual migration failed: {Message}", ex.Message);
        return Results.Problem($"Migration failed: {ex.Message}", statusCode: 500);
    }
})
.RequireAuthorization(policy => policy.RequireRole("Admin"));

// Add health check endpoint to verify Products table
app.MapGet("/api/health/database", async (LibraryDbContext context) =>
{
    try
    {
        // Check if Products table exists
        var productTableExists = false;
        try
        {
            await context.Database.ExecuteSqlRawAsync("SELECT 1 FROM \"Products\" LIMIT 1");
            productTableExists = true;
        }
        catch { /* Table doesn't exist */ }

        // Get basic stats
        var bookCount = await context.Books.CountAsync();
        var categoryCount = await context.Categories.CountAsync();

        return Results.Ok(new
        {
            status = "healthy",
            database = "connected",
            productsTable = productTableExists ? "exists" : "missing",
            books = bookCount,
            categories = categoryCount,
            timestamp = DateTime.UtcNow
        });
    }
    catch (Exception ex)
    {
        return Results.Problem($"Database health check failed: {ex.Message}", statusCode: 503);
    }
});

app.MapControllers();

// Initialize database and seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<LibraryDbContext>();
        var userManager = services.GetRequiredService<UserManager<User>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        try
        {
            // Apply migrations with detailed logging - BLOCKING UNTIL COMPLETE
            var dbLogger = services.GetRequiredService<ILogger<Program>>();
            dbLogger.LogInformation("🚀 Starting database migration...");

            // Always run migration to ensure Products table exists
            dbLogger.LogInformation("📋 Running database migration to ensure all tables exist...");

            try
            {
                // Run the migration synchronously and wait for completion
                await context.Database.MigrateAsync();
                dbLogger.LogInformation("✅ Database migration completed successfully!");

                // Fix existing HTTP URLs to HTTPS
                await FixImageUrlsToHttpsAsync(context, dbLogger);
            }
            catch (Exception migEx)
            {
                dbLogger.LogWarning(migEx, "EF Migration failed, attempting manual SQL migration...");

                // Fallback: Execute manual SQL migration
                await ExecuteManualMigrationAsync(context, dbLogger);
            }

            // Seed roles
            await SeedRolesAsync(roleManager);
            dbLogger.LogInformation("👥 Roles seeded successfully!");

            // Seed admin user
            await SeedAdminUserAsync(userManager);
            dbLogger.LogInformation("👤 Admin user seeded successfully!");

            // Fix existing HTTP URLs to HTTPS
            await FixImageUrlsToHttpsAsync(context, dbLogger);

            dbLogger.LogInformation("🎉 Database setup completed successfully!");
        }
        catch (Exception dbEx)
        {
            var dbLogger = services.GetRequiredService<ILogger<Program>>();
            dbLogger.LogError(dbEx, "Database migration/seed failed. Error: {Message}. StackTrace: {StackTrace}", dbEx.Message, dbEx.StackTrace);

            // Don't fail the application startup, just log the error
            dbLogger.LogWarning("Application will continue without database initialization.");
        }
    }
    catch (Exception ex)
    {
        var seedLogger = services.GetRequiredService<ILogger<Program>>();
        seedLogger.LogError(ex, "An error occurred while seeding the database.");
    }
}

app.Run();

// Helper methods for seeding
static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
{
    string[] roles = { "Admin", "Librarian", "Customer" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

static async Task FixImageUrlsToHttpsAsync(LibraryDbContext context, ILogger logger)
{
    try
    {
        logger.LogInformation("🔄 Checking for HTTP URLs to convert to HTTPS...");

        // Fix Books table HTTP URLs
        var booksWithHttpUrls = await context.Books
            .Where(b => b.CoverImageUrl != null && b.CoverImageUrl.StartsWith("http://"))
            .ToListAsync();

        if (booksWithHttpUrls.Any())
        {
            foreach (var book in booksWithHttpUrls)
            {
                book.CoverImageUrl = book.CoverImageUrl!.Replace("http://", "https://");
            }
            await context.SaveChangesAsync();
            logger.LogInformation($"✅ Fixed {booksWithHttpUrls.Count} book image URLs from HTTP to HTTPS");
        }

        // Fix Products table HTTP URLs
        var productsWithHttpUrls = await context.Products
            .Where(p => p.CoverImageUrl != null && p.CoverImageUrl.StartsWith("http://"))
            .ToListAsync();

        if (productsWithHttpUrls.Any())
        {
            foreach (var product in productsWithHttpUrls)
            {
                product.CoverImageUrl = product.CoverImageUrl!.Replace("http://", "https://");
            }
            await context.SaveChangesAsync();
            logger.LogInformation($"✅ Fixed {productsWithHttpUrls.Count} product image URLs from HTTP to HTTPS");
        }

        // Fix BookImages table HTTP URLs
        var bookImagesWithHttpUrls = await context.BookImages
            .Where(bi => bi.ImageUrl != null && bi.ImageUrl.StartsWith("http://"))
            .ToListAsync();

        if (bookImagesWithHttpUrls.Any())
        {
            foreach (var bookImage in bookImagesWithHttpUrls)
            {
                bookImage.ImageUrl = bookImage.ImageUrl!.Replace("http://", "https://");
            }
            await context.SaveChangesAsync();
            logger.LogInformation($"✅ Fixed {bookImagesWithHttpUrls.Count} book gallery image URLs from HTTP to HTTPS");
        }

        // Fix ProductImages table HTTP URLs
        var productImagesWithHttpUrls = await context.ProductImages
            .Where(pi => pi.ImageUrl != null && pi.ImageUrl.StartsWith("http://"))
            .ToListAsync();

        if (productImagesWithHttpUrls.Any())
        {
            foreach (var productImage in productImagesWithHttpUrls)
            {
                productImage.ImageUrl = productImage.ImageUrl!.Replace("http://", "https://");
            }
            await context.SaveChangesAsync();
            logger.LogInformation($"✅ Fixed {productImagesWithHttpUrls.Count} product gallery image URLs from HTTP to HTTPS");
        }

        logger.LogInformation("🎉 URL fixing completed successfully!");
    }
    catch (Exception ex)
    {
        logger.LogWarning(ex, "Failed to fix HTTP URLs to HTTPS: {Message}", ex.Message);
    }
}

static async Task SeedAdminUserAsync(UserManager<User> userManager)
{
    var adminEmail = "admin@library.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);

    if (adminUser == null)
    {
        adminUser = new User
        {
            FirstName = "System",
            LastName = "Administrator",
            UserName = "admin",
            Email = adminEmail,
            EmailConfirmed = true,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var result = await userManager.CreateAsync(adminUser, "Admin123!");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}

static async Task ExecuteManualMigrationAsync(LibraryDbContext context, ILogger logger)
{
    try
    {
        logger.LogInformation("🔧 Executing manual SQL migration for Products table...");

        // Step 1: Create Products table
        await context.Database.ExecuteSqlRawAsync(@"
            CREATE TABLE IF NOT EXISTS ""Products"" (
                ""Id"" SERIAL PRIMARY KEY,
                ""Title"" VARCHAR(200) NOT NULL,
                ""TitleArabic"" VARCHAR(200),
                ""SKU"" VARCHAR(20),
                ""Description"" TEXT,
                ""DescriptionArabic"" TEXT,
                ""ProductType"" VARCHAR(50) NOT NULL DEFAULT 'Book',
                ""AuthorId"" INTEGER,
                ""PublisherId"" INTEGER,
                ""CategoryId"" INTEGER,
                ""Grade"" VARCHAR(50),
                ""Subject"" VARCHAR(50),
                ""PublicationDate"" TIMESTAMP WITH TIME ZONE,
                ""Pages"" INTEGER,
                ""Language"" VARCHAR(20) NOT NULL DEFAULT 'Arabic',
                ""Price"" DECIMAL(10,2),
                ""OriginalPrice"" DECIMAL(10,2),
                ""StockQuantity"" INTEGER NOT NULL DEFAULT 0,
                ""CoverImageUrl"" VARCHAR(500),
                ""IsAvailable"" BOOLEAN NOT NULL DEFAULT TRUE,
                ""IsFeatured"" BOOLEAN NOT NULL DEFAULT FALSE,
                ""IsNewRelease"" BOOLEAN NOT NULL DEFAULT FALSE,
                ""Rating"" DECIMAL(3,2) NOT NULL DEFAULT 0.0,
                ""RatingCount"" INTEGER NOT NULL DEFAULT 0,
                ""ViewCount"" INTEGER NOT NULL DEFAULT 0,
                ""CreatedAt"" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
                ""UpdatedAt"" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP
            );
        ");
        logger.LogInformation("📋 Products table created/verified");

        // Step 2: Create ProductImages table
        await context.Database.ExecuteSqlRawAsync(@"
            CREATE TABLE IF NOT EXISTS ""ProductImages"" (
                ""Id"" SERIAL PRIMARY KEY,
                ""ProductId"" INTEGER NOT NULL,
                ""ImageUrl"" VARCHAR(500) NOT NULL,
                ""ImageType"" VARCHAR(50) NOT NULL DEFAULT 'Gallery',
                ""DisplayOrder"" INTEGER NOT NULL DEFAULT 0,
                ""IsActive"" BOOLEAN NOT NULL DEFAULT TRUE,
                ""CreatedAt"" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP
            );
        ");
        logger.LogInformation("📋 ProductImages table created/verified");

        // Step 3: Add foreign key constraints (simplified approach)
        try
        {
            await context.Database.ExecuteSqlRawAsync(@"
                ALTER TABLE ""Products"" ADD CONSTRAINT ""FK_Products_Authors_AuthorId""
                    FOREIGN KEY (""AuthorId"") REFERENCES ""Authors"" (""Id"") ON DELETE SET NULL;
            ");
            logger.LogInformation("🔗 Added FK: Products.AuthorId");
        }
        catch (Exception ex)
        {
            logger.LogWarning("FK Products.AuthorId may already exist: {Message}", ex.Message);
        }

        try
        {
            await context.Database.ExecuteSqlRawAsync(@"
                ALTER TABLE ""Products"" ADD CONSTRAINT ""FK_Products_Categories_CategoryId""
                    FOREIGN KEY (""CategoryId"") REFERENCES ""Categories"" (""Id"") ON DELETE SET NULL;
            ");
            logger.LogInformation("🔗 Added FK: Products.CategoryId");
        }
        catch (Exception ex)
        {
            logger.LogWarning("FK Products.CategoryId may already exist: {Message}", ex.Message);
        }

        try
        {
            await context.Database.ExecuteSqlRawAsync(@"
                ALTER TABLE ""Products"" ADD CONSTRAINT ""FK_Products_Publishers_PublisherId""
                    FOREIGN KEY (""PublisherId"") REFERENCES ""Publishers"" (""Id"") ON DELETE SET NULL;
            ");
            logger.LogInformation("🔗 Added FK: Products.PublisherId");
        }
        catch (Exception ex)
        {
            logger.LogWarning("FK Products.PublisherId may already exist: {Message}", ex.Message);
        }

        try
        {
            await context.Database.ExecuteSqlRawAsync(@"
                ALTER TABLE ""ProductImages"" ADD CONSTRAINT ""FK_ProductImages_Products_ProductId""
                    FOREIGN KEY (""ProductId"") REFERENCES ""Products"" (""Id"") ON DELETE CASCADE;
            ");
            logger.LogInformation("🔗 Added FK: ProductImages.ProductId");
        }
        catch (Exception ex)
        {
            logger.LogWarning("FK ProductImages.ProductId may already exist: {Message}", ex.Message);
        }

        // Step 4: Add indexes
        await context.Database.ExecuteSqlRawAsync(@"
            CREATE INDEX IF NOT EXISTS ""IX_Products_IsAvailable"" ON ""Products"" (""IsAvailable"");
            CREATE INDEX IF NOT EXISTS ""IX_Products_IsFeatured"" ON ""Products"" (""IsFeatured"");
            CREATE INDEX IF NOT EXISTS ""IX_Products_IsNewRelease"" ON ""Products"" (""IsNewRelease"");
            CREATE INDEX IF NOT EXISTS ""IX_ProductImages_ProductId"" ON ""ProductImages"" (""ProductId"");
        ");
        logger.LogInformation("📊 Indexes created/verified");

        logger.LogInformation("✅ Manual SQL migration completed successfully!");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Manual SQL migration failed: {Message}", ex.Message);
        throw; // Re-throw to let the application know migration failed
    }
}

