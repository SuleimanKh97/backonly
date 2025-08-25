using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NameArabic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Biography = table.Column<string>(type: "text", nullable: true),
                    BiographyArabic = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Nationality = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NameArabic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DescriptionArabic = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NameArabic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Website = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TitleArabic = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Subject = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Teacher = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DescriptionArabic = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric(10,2)", nullable: false, defaultValue: 0.0m),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "متوفر"),
                    Delivery = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, defaultValue: "PDF / طباعة"),
                    Rating = table.Column<decimal>(type: "numeric(3,2)", nullable: false, defaultValue: 0.0m),
                    Downloads = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Duration = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Features = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyMaterials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudySchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Day = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    TitleArabic = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DescriptionArabic = table.Column<string>(type: "text", nullable: true),
                    Grade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Subjects = table.Column<string>(type: "text", nullable: true),
                    Focus = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    FocusArabic = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    OrderIndex = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudySchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyTips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Category = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TitleArabic = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DescriptionArabic = table.Column<string>(type: "text", nullable: true),
                    Grade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Subject = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Tips = table.Column<string>(type: "text", nullable: true),
                    OrderIndex = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyTips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SettingKey = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SettingValue = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TitleArabic = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DescriptionArabic = table.Column<string>(type: "text", nullable: true),
                    Subject = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Grade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Chapter = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TimeLimit = table.Column<int>(type: "integer", nullable: false, defaultValue: 30),
                    TotalQuestions = table.Column<int>(type: "integer", nullable: false),
                    PassingScore = table.Column<int>(type: "integer", nullable: false, defaultValue: 60),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quizzes_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TitleArabic = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ISBN = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DescriptionArabic = table.Column<string>(type: "text", nullable: true),
                    AuthorId = table.Column<int>(type: "integer", nullable: true),
                    PublisherId = table.Column<int>(type: "integer", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Pages = table.Column<int>(type: "integer", nullable: true),
                    Language = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, defaultValue: "Arabic"),
                    Price = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    OriginalPrice = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    StockQuantity = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CoverImageUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsFeatured = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsNewRelease = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Rating = table.Column<decimal>(type: "numeric(3,2)", nullable: false, defaultValue: 0.0m),
                    RatingCount = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ViewCount = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "QuizAttempts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuizId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Score = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    TotalScore = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Percentage = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    IsPassed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    TimeSpent = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Status = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizAttempts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizAttempts_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuizId = table.Column<int>(type: "integer", nullable: false),
                    QuestionText = table.Column<string>(type: "text", nullable: false),
                    QuestionTextArabic = table.Column<string>(type: "text", nullable: true),
                    Explanation = table.Column<string>(type: "text", nullable: true),
                    ExplanationArabic = table.Column<string>(type: "text", nullable: true),
                    Points = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    OrderIndex = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Type = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ImageType = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookImages_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookInquiries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    CustomerName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CustomerPhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CustomerEmail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    WhatsAppMessageSent = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    ResponseMessage = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookInquiries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookInquiries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BookInquiries_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    OptionText = table.Column<string>(type: "text", nullable: false),
                    OptionTextArabic = table.Column<string>(type: "text", nullable: true),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    OrderIndex = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionOptions_QuizQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "QuizQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttemptAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttemptId = table.Column<int>(type: "integer", nullable: false),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    SelectedOptionId = table.Column<int>(type: "integer", nullable: true),
                    TextAnswer = table.Column<string>(type: "text", nullable: true),
                    BooleanAnswer = table.Column<bool>(type: "boolean", nullable: true),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    PointsEarned = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    AnsweredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttemptAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttemptAnswers_QuestionOptions_SelectedOptionId",
                        column: x => x.SelectedOptionId,
                        principalTable: "QuestionOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AttemptAnswers_QuizAttempts_AttemptId",
                        column: x => x.AttemptId,
                        principalTable: "QuizAttempts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttemptAnswers_QuizQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "QuizQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "BiographyArabic", "BirthDate", "CreatedAt", "IsActive", "Name", "NameArabic", "Nationality", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Egyptian poet and playwright", "شاعر وكاتب مسرحي مصري", null, new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8289), true, "Ahmed Shawqi", "أحمد شوقي", "Egyptian", new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8442) },
                    { 2, "Egyptian writer and intellectual", "كاتب ومفكر مصري", null, new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8556), true, "Taha Hussein", "طه حسين", "Egyptian", new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8556) },
                    { 3, "Egyptian philosopher and writer", "فيلسوف وكاتب مصري", null, new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8559), true, "Zaki Naguib Mahmoud", "زكي نجيب محمود", "Egyptian", new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8559) },
                    { 4, "Nobel Prize-winning Egyptian writer", "كاتب مصري حائز على جائزة نوبل", null, new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8561), true, "Naguib Mahfouz", "نجيب محفوظ", "Egyptian", new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8562) },
                    { 5, "Lebanese-American writer and poet", "كاتب وشاعر لبناني أمريكي", null, new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8564), true, "Khalil Gibran", "جبران خليل جبران", "Lebanese", new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8564) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "DescriptionArabic", "Icon", "IsActive", "Name", "NameArabic", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(7651), "Fiction and literature books", "كتب الأدب والرواية", "fas fa-feather-alt", true, "Literature", "الأدب والرواية", new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(7651) },
                    { 2, new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8151), "Science and research books", "كتب العلوم والبحث", "fas fa-flask", true, "Science", "العلوم", new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8151) },
                    { 3, new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8153), "History and civilization books", "كتب التاريخ والحضارة", "fas fa-landmark", true, "History", "التاريخ", new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8153) },
                    { 4, new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8155), "Religious and Islamic studies", "الكتب الدينية والدراسات الإسلامية", "fas fa-mosque", true, "Religion", "الدين", new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8155) },
                    { 5, new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8156), "Technology and programming books", "كتب التكنولوجيا والبرمجة", "fas fa-laptop-code", true, "Technology", "التكنولوجيا", new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8157) },
                    { 6, new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8168), "Philosophy and thought books", "كتب الفلسفة والفكر", "fas fa-brain", true, "Philosophy", "الفلسفة", new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8168) }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "IsActive", "Name", "NameArabic", "Phone", "UpdatedAt", "Website" },
                values: new object[,]
                {
                    { 1, "Cairo, Egypt", new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(6825), "info@daralmaarif.com", true, "Dar Al-Ma'arif", "دار المعارف", "+20123456789", new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(6920), "www.daralmaarif.com" },
                    { 2, "Cairo, Egypt", new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(7008), "info@shorouk.com", true, "Dar Al-Shorouk", "دار الشروق", "+20123456790", new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(7009), "www.shorouk.com" },
                    { 3, "Beirut, Lebanon", new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(7012), "info@arabicbook.com", true, "Dar Al-Kitab Al-Arabi", "دار الكتاب العربي", "+96112345678", new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(7012), "www.arabicbook.com" },
                    { 4, "Damascus, Syria", new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(7014), "info@alfikr.com", true, "Dar Al-Fikr", "دار الفكر", "+96312345678", new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(7014), "www.alfikr.com" }
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Chapter", "CreatedAt", "CreatedBy", "Description", "DescriptionArabic", "Grade", "IsActive", "IsPublic", "PassingScore", "Subject", "TimeLimit", "Title", "TitleArabic", "TotalQuestions", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Algebra", new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(5222), null, "Basic mathematics quiz for 10th grade students", "كويز أساسيات الرياضيات لطلاب الصف العاشر", "Grade 10", true, true, 60, "Mathematics", 20, "Mathematics Quiz - Grade 10", "كويز الرياضيات - الصف العاشر", 5, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(5325) },
                    { 2, "Mechanics", new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(5424), null, "Physics fundamentals for Tawjihi students", "أساسيات الفيزياء لطلاب التوجيهي", "Tawjihi", true, true, 70, "Physics", 25, "Physics Quiz - Tawjihi", "كويز الفيزياء - التوجيهي", 6, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(5425) },
                    { 3, "Atomic Structure", new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(5429), null, "Chemistry basics for 11th grade students", "أساسيات الكيمياء لطلاب الصف الحادي عشر", "Grade 11", true, true, 75, "Chemistry", 15, "Chemistry Quiz - Grade 11", "كويز الكيمياء - الصف الحادي عشر", 4, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(5429) }
                });

            migrationBuilder.InsertData(
                table: "SystemSettings",
                columns: new[] { "Id", "Description", "SettingKey", "SettingValue", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Library WhatsApp contact number", "WhatsAppPhoneNumber", "+962785462983", new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2555) },
                    { 2, "WhatsApp message template for book inquiries", "WhatsAppMessageTemplate", "مرحباً، أود الاستفسار عن توفر كتاب: {BookTitle} - {BookAuthor}", new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2896) },
                    { 3, "Library name", "LibraryName", "ROYAL STUDY", new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2898) },
                    { 4, "Library name in English", "LibraryNameEnglish", "ROYAL STUDY", new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2899) },
                    { 5, "Library contact email", "ContactEmail", "info@royalstudy.com", new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2900) },
                    { 6, "Library contact phone", "ContactPhone", "+962785462983", new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2901) },
                    { 7, "Library address", "LibraryAddress", "إربد، الأردن", new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2902) },
                    { 8, "Library address in English", "LibraryAddressEnglish", "Irbid, Jordan", new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2903) },
                    { 9, "Library currency", "Currency", "د.أ", new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2903) },
                    { 10, "Library currency in English", "CurrencyEnglish", "JOD", new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2904) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CoverImageUrl", "CreatedAt", "Description", "DescriptionArabic", "ISBN", "IsAvailable", "IsFeatured", "Language", "OriginalPrice", "Pages", "Price", "PublicationDate", "PublisherId", "Rating", "RatingCount", "StockQuantity", "Title", "TitleArabic", "UpdatedAt", "ViewCount" },
                values: new object[] { 1, 5, 6, null, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1681), "A book of 26 prose poetry essays written in English by the Lebanese-American poet and writer Kahlil Gibran", "كتاب يحتوي على 26 مقالة شعرية نثرية كتبها الشاعر والكاتب اللبناني الأمريكي جبران خليل جبران", "978-0-394-71585-9", true, true, "Arabic", 50.00m, null, 45.00m, null, 3, 4.8m, 150, 25, "The Prophet", "النبي", new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1761), 500 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CoverImageUrl", "CreatedAt", "Description", "DescriptionArabic", "ISBN", "IsAvailable", "IsNewRelease", "Language", "OriginalPrice", "Pages", "Price", "PublicationDate", "PublisherId", "Rating", "RatingCount", "StockQuantity", "Title", "TitleArabic", "UpdatedAt", "ViewCount" },
                values: new object[] { 2, 2, 1, null, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1846), "An autobiographical novel by Taha Hussein", "رواية سيرة ذاتية لطه حسين", "978-977-02-1234-5", true, true, "Arabic", 40.00m, null, 35.00m, null, 1, 4.5m, 89, 15, "The Days", "الأيام", new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1847), 320 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CoverImageUrl", "CreatedAt", "Description", "DescriptionArabic", "ISBN", "IsAvailable", "Language", "OriginalPrice", "Pages", "Price", "PublicationDate", "PublisherId", "Rating", "RatingCount", "StockQuantity", "Title", "TitleArabic", "UpdatedAt", "ViewCount" },
                values: new object[] { 3, 3, 6, null, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1852), "An introduction to the philosophy of science", "مقدمة في فلسفة العلوم", "978-977-09-5678-9", true, "Arabic", 60.00m, null, 55.00m, null, 2, 4.2m, 45, 8, "Philosophy of Science", "فلسفة العلوم", new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1853), 180 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CoverImageUrl", "CreatedAt", "Description", "DescriptionArabic", "ISBN", "IsAvailable", "IsFeatured", "Language", "OriginalPrice", "Pages", "Price", "PublicationDate", "PublisherId", "Rating", "RatingCount", "StockQuantity", "Title", "TitleArabic", "UpdatedAt", "ViewCount" },
                values: new object[] { 4, 4, 1, null, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1872), "A novel by Nobel Prize winner Naguib Mahfouz", "رواية للكاتب نجيب محفوظ الحائز على جائزة نوبل", "978-977-02-9012-3", true, true, "Arabic", 45.00m, null, 40.00m, null, 1, 4.7m, 120, 12, "Children of Gebelawi", "أولاد حارتنا", new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1873), 450 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CoverImageUrl", "CreatedAt", "Description", "DescriptionArabic", "ISBN", "IsAvailable", "Language", "OriginalPrice", "Pages", "Price", "PublicationDate", "PublisherId", "Rating", "RatingCount", "StockQuantity", "Title", "TitleArabic", "UpdatedAt", "ViewCount" },
                values: new object[] { 5, 1, 1, null, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1878), "Collection of poems by Ahmed Shawqi", "مجموعة شعرية لأحمد شوقي", "978-963-12-3456-7", true, "Arabic", 35.00m, null, 30.00m, null, 4, 4.3m, 67, 20, "Poetry Collection", "ديوان شعر", new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1878), 250 });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "CreatedAt", "Explanation", "ExplanationArabic", "OrderIndex", "Points", "QuestionText", "QuestionTextArabic", "QuizId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7088), null, null, 1, 1, "What is the value of x in the equation 2x + 5 = 13?", "ما قيمة س في المعادلة 2س + 5 = 13؟", 1, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7173) },
                    { 2, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7262), null, null, 2, 1, "Solve: 3x - 7 = 8", "حل المعادلة: 3س - 7 = 8", 1, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7263) }
                });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "CreatedAt", "Explanation", "ExplanationArabic", "OrderIndex", "Points", "QuestionText", "QuestionTextArabic", "QuizId", "Type", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7265), null, null, 3, 1, "The square root of 16 is 4", "الجذر التربيعي لـ 16 هو 4", 1, 1, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7266) });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "CreatedAt", "Explanation", "ExplanationArabic", "OrderIndex", "Points", "QuestionText", "QuestionTextArabic", "QuizId", "UpdatedAt" },
                values: new object[] { 4, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7268), null, null, 4, 1, "What is 15% of 200?", "ما هو 15% من 200؟", 1, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7269) });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "CreatedAt", "Explanation", "ExplanationArabic", "OrderIndex", "Points", "QuestionText", "QuestionTextArabic", "QuizId", "Type", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7271), null, null, 5, 1, "The sum of angles in a triangle is 180 degrees", "مجموع زوايا المثلث 180 درجة", 1, 1, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7271) });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "CreatedAt", "Explanation", "ExplanationArabic", "OrderIndex", "Points", "QuestionText", "QuestionTextArabic", "QuizId", "UpdatedAt" },
                values: new object[] { 6, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7599), null, null, 1, 1, "What is the SI unit of force?", "ما هي وحدة القوة في النظام الدولي؟", 2, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7600) });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "CreatedAt", "Explanation", "ExplanationArabic", "OrderIndex", "Points", "QuestionText", "QuestionTextArabic", "QuizId", "Type", "UpdatedAt" },
                values: new object[] { 7, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7602), null, null, 2, 1, "Newton's first law is also known as the law of inertia", "قانون نيوتن الأول يعرف أيضاً بقانون القصور الذاتي", 2, 1, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7603) });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "CreatedAt", "Explanation", "ExplanationArabic", "OrderIndex", "Points", "QuestionText", "QuestionTextArabic", "QuizId", "UpdatedAt" },
                values: new object[] { 8, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7605), null, null, 3, 1, "What is the formula for kinetic energy?", "ما هي معادلة الطاقة الحركية؟", 2, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7605) });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "CreatedAt", "Explanation", "ExplanationArabic", "OrderIndex", "Points", "QuestionText", "QuestionTextArabic", "QuizId", "Type", "UpdatedAt" },
                values: new object[] { 9, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7608), null, null, 4, 1, "Gravity is a force that pulls objects toward the center of the Earth", "الجاذبية قوة تجذب الأجسام نحو مركز الأرض", 2, 1, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7608) });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "CreatedAt", "Explanation", "ExplanationArabic", "OrderIndex", "Points", "QuestionText", "QuestionTextArabic", "QuizId", "UpdatedAt" },
                values: new object[] { 10, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7610), null, null, 5, 1, "What is the unit of power?", "ما هي وحدة القدرة؟", 2, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7611) });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "CreatedAt", "Explanation", "ExplanationArabic", "OrderIndex", "Points", "QuestionText", "QuestionTextArabic", "QuizId", "Type", "UpdatedAt" },
                values: new object[] { 11, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7718), null, null, 6, 1, "Velocity is a scalar quantity", "السرعة كمية قياسية", 2, 1, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7719) });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "CreatedAt", "Explanation", "ExplanationArabic", "OrderIndex", "Points", "QuestionText", "QuestionTextArabic", "QuizId", "UpdatedAt" },
                values: new object[] { 12, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7751), null, null, 1, 1, "What is the atomic number of hydrogen?", "ما هو العدد الذري للهيدروجين؟", 3, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7752) });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "CreatedAt", "Explanation", "ExplanationArabic", "OrderIndex", "Points", "QuestionText", "QuestionTextArabic", "QuizId", "Type", "UpdatedAt" },
                values: new object[] { 13, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7754), null, null, 2, 1, "The nucleus contains protons and neutrons", "النواة تحتوي على البروتونات والنيوترونات", 3, 1, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7755) });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "CreatedAt", "Explanation", "ExplanationArabic", "OrderIndex", "Points", "QuestionText", "QuestionTextArabic", "QuizId", "UpdatedAt" },
                values: new object[] { 14, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7760), null, null, 3, 1, "What is the chemical symbol for gold?", "ما هو الرمز الكيميائي للذهب؟", 3, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7760) });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "CreatedAt", "Explanation", "ExplanationArabic", "OrderIndex", "Points", "QuestionText", "QuestionTextArabic", "QuizId", "Type", "UpdatedAt" },
                values: new object[] { 15, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7762), null, null, 4, 1, "Electrons have a positive charge", "الإلكترونات لها شحنة موجبة", 3, 1, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7762) });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "CreatedAt", "IsCorrect", "OptionText", "OptionTextArabic", "OrderIndex", "QuestionId", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(8835), true, "4", "4", 1, 1, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(8926) });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "CreatedAt", "OptionText", "OptionTextArabic", "OrderIndex", "QuestionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9004), "6", "6", 2, 1, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9004) },
                    { 3, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9006), "8", "8", 3, 1, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9007) },
                    { 4, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9008), "10", "10", 4, 1, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9009) }
                });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "CreatedAt", "IsCorrect", "OptionText", "OptionTextArabic", "OrderIndex", "QuestionId", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9011), true, "5", "5", 1, 2, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9011) });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "CreatedAt", "OptionText", "OptionTextArabic", "OrderIndex", "QuestionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 6, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9013), "3", "3", 2, 2, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9013) },
                    { 7, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9015), "7", "7", 3, 2, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9015) },
                    { 8, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9017), "9", "9", 4, 2, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9017) }
                });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "CreatedAt", "IsCorrect", "OptionText", "OptionTextArabic", "OrderIndex", "QuestionId", "UpdatedAt" },
                values: new object[] { 9, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9052), true, "30", "30", 1, 4, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9052) });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "CreatedAt", "OptionText", "OptionTextArabic", "OrderIndex", "QuestionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 10, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9054), "25", "25", 2, 4, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9054) },
                    { 11, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9056), "35", "35", 3, 4, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9056) },
                    { 12, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9058), "40", "40", 4, 4, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9059) }
                });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "CreatedAt", "IsCorrect", "OptionText", "OptionTextArabic", "OrderIndex", "QuestionId", "UpdatedAt" },
                values: new object[] { 13, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9264), true, "Newton", "نيوتن", 1, 6, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9265) });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "CreatedAt", "OptionText", "OptionTextArabic", "OrderIndex", "QuestionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 14, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9267), "Joule", "جول", 2, 6, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9267) },
                    { 15, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9269), "Watt", "واط", 3, 6, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9269) },
                    { 16, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9271), "Pascal", "باسكال", 4, 6, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9271) }
                });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "CreatedAt", "IsCorrect", "OptionText", "OptionTextArabic", "OrderIndex", "QuestionId", "UpdatedAt" },
                values: new object[] { 17, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9273), true, "KE = 1/2 mv²", "ط ح = 1/2 ك ع²", 1, 8, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9274) });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "CreatedAt", "OptionText", "OptionTextArabic", "OrderIndex", "QuestionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 18, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9275), "KE = mv", "ط ح = ك ع", 2, 8, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9276) },
                    { 19, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9278), "KE = mgh", "ط ح = ك ج ع", 3, 8, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9278) },
                    { 20, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9280), "KE = Fd", "ط ح = ق ف", 4, 8, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9280) }
                });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "CreatedAt", "IsCorrect", "OptionText", "OptionTextArabic", "OrderIndex", "QuestionId", "UpdatedAt" },
                values: new object[] { 21, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9282), true, "Watt", "واط", 1, 10, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9282) });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "CreatedAt", "OptionText", "OptionTextArabic", "OrderIndex", "QuestionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 22, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9284), "Joule", "جول", 2, 10, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9284) },
                    { 23, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9288), "Newton", "نيوتن", 3, 10, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9288) },
                    { 24, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9290), "Meter", "متر", 4, 10, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9290) }
                });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "CreatedAt", "IsCorrect", "OptionText", "OptionTextArabic", "OrderIndex", "QuestionId", "UpdatedAt" },
                values: new object[] { 25, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9310), true, "1", "1", 1, 12, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9310) });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "CreatedAt", "OptionText", "OptionTextArabic", "OrderIndex", "QuestionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 26, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9312), "2", "2", 2, 12, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9313) },
                    { 27, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9314), "3", "3", 3, 12, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9315) },
                    { 28, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9316), "4", "4", 4, 12, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9317) }
                });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "CreatedAt", "IsCorrect", "OptionText", "OptionTextArabic", "OrderIndex", "QuestionId", "UpdatedAt" },
                values: new object[] { 29, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9319), true, "Au", "Au", 1, 14, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9319) });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "CreatedAt", "OptionText", "OptionTextArabic", "OrderIndex", "QuestionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 30, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9320), "Ag", "Ag", 2, 14, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9321) },
                    { 31, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9323), "Cu", "Cu", 3, 14, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9323) },
                    { 32, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9325), "Fe", "Fe", 4, 14, new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9325) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttemptAnswers_AttemptId",
                table: "AttemptAnswers",
                column: "AttemptId");

            migrationBuilder.CreateIndex(
                name: "IX_AttemptAnswers_QuestionId",
                table: "AttemptAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttemptAnswers_SelectedOptionId",
                table: "AttemptAnswers",
                column: "SelectedOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_Name",
                table: "Authors",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_BookImages_BookId",
                table: "BookImages",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookInquiries_BookId",
                table: "BookInquiries",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookInquiries_CreatedAt",
                table: "BookInquiries",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_BookInquiries_Status",
                table: "BookInquiries",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_BookInquiries_UserId",
                table: "BookInquiries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_IsAvailable",
                table: "Books",
                column: "IsAvailable");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ISBN",
                table: "Books",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_IsFeatured",
                table: "Books",
                column: "IsFeatured");

            migrationBuilder.CreateIndex(
                name: "IX_Books_IsNewRelease",
                table: "Books",
                column: "IsNewRelease");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Title",
                table: "Books",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_Name",
                table: "Publishers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOptions_IsCorrect",
                table: "QuestionOptions",
                column: "IsCorrect");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOptions_QuestionId",
                table: "QuestionOptions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAttempts_QuizId",
                table: "QuizAttempts",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAttempts_StartedAt",
                table: "QuizAttempts",
                column: "StartedAt");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAttempts_Status",
                table: "QuizAttempts",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAttempts_UserId",
                table: "QuizAttempts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_OrderIndex",
                table: "QuizQuestions",
                column: "OrderIndex");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuizId",
                table: "QuizQuestions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_CreatedBy",
                table: "Quizzes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_Grade",
                table: "Quizzes",
                column: "Grade");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_IsActive",
                table: "Quizzes",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_Subject",
                table: "Quizzes",
                column: "Subject");

            migrationBuilder.CreateIndex(
                name: "IX_StudyMaterials_Category",
                table: "StudyMaterials",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_StudyMaterials_IsActive",
                table: "StudyMaterials",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_StudyMaterials_Subject",
                table: "StudyMaterials",
                column: "Subject");

            migrationBuilder.CreateIndex(
                name: "IX_StudySchedules_Grade",
                table: "StudySchedules",
                column: "Grade");

            migrationBuilder.CreateIndex(
                name: "IX_StudySchedules_IsActive",
                table: "StudySchedules",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_StudySchedules_Type",
                table: "StudySchedules",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_StudyTips_Category",
                table: "StudyTips",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_StudyTips_Grade",
                table: "StudyTips",
                column: "Grade");

            migrationBuilder.CreateIndex(
                name: "IX_StudyTips_IsActive",
                table: "StudyTips",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_StudyTips_Subject",
                table: "StudyTips",
                column: "Subject");

            migrationBuilder.CreateIndex(
                name: "IX_SystemSettings_SettingKey",
                table: "SystemSettings",
                column: "SettingKey",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AttemptAnswers");

            migrationBuilder.DropTable(
                name: "BookImages");

            migrationBuilder.DropTable(
                name: "BookInquiries");

            migrationBuilder.DropTable(
                name: "StudyMaterials");

            migrationBuilder.DropTable(
                name: "StudySchedules");

            migrationBuilder.DropTable(
                name: "StudyTips");

            migrationBuilder.DropTable(
                name: "SystemSettings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "QuestionOptions");

            migrationBuilder.DropTable(
                name: "QuizAttempts");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "QuizQuestions");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
