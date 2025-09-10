using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LibraryManagementAPI.DTOs;
using LibraryManagementAPI.Services;
using LibraryManagementAPI.Data;
using System.Security.Claims;

namespace LibraryManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _environment;

        public ProductsController(IProductService productService, IWebHostEnvironment environment)
        {
            _productService = productService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductSearchDto searchDto)
        {
            var result = await _productService.GetProductsAsync(searchDto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            // Increment view count
            await _productService.IncrementViewCountAsync(id);

            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            // Debug logging
            var user = HttpContext.User;
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = user.FindFirst(ClaimTypes.Role)?.Value;
            var userName = user.FindFirst(ClaimTypes.Name)?.Value;

            Console.WriteLine($"CreateProduct called by User: {userName}, ID: {userId}, Role: {userRole}, IsAuthenticated: {user.Identity?.IsAuthenticated}");

            if (user.Identity?.IsAuthenticated != true)
            {
                return Unauthorized(new { message = "User is not authenticated" });
            }

            if (!user.IsInRole("Admin") && !user.IsInRole("Librarian"))
            {
                return Forbid($"User role '{userRole}' is not authorized for this action");
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState
                        .Where(x => x.Value?.Errors.Count > 0)
                        .Select(x => new { Field = x.Key, Errors = x.Value?.Errors.Select(e => e.ErrorMessage) ?? new List<string>() })
                        .ToList();
                    
                    return BadRequest(new { 
                        message = "Validation failed", 
                        errors = errors 
                    });
                }

                var product = await _productService.CreateProductAsync(createProductDto);
                if (product == null)
                    return BadRequest(new { message = "Failed to create product. Please check your data and try again." });

                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                // Log the full exception for debugging
                Console.WriteLine($"Product creation error: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                Console.WriteLine($"Inner exception: {ex.InnerException?.Message}");

                return BadRequest(new {
                    message = "An error occurred while creating the product",
                    details = ex.Message,
                    innerDetails = ex.InnerException?.Message,
                    suggestion = "Please check if the SKU is unique and all referenced IDs (Author, Publisher, Category) exist."
                });
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _productService.UpdateProductAsync(id, updateProductDto);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if (!result)
                return NotFound();

            return Ok(new { message = "Product deleted successfully" });
        }

        [HttpGet("featured")]
        public async Task<IActionResult> GetFeaturedProducts([FromQuery] int count = 10)
        {
            var products = await _productService.GetFeaturedProductsAsync(count);
            return Ok(products);
        }

        [HttpGet("new-releases")]
        public async Task<IActionResult> GetNewReleases([FromQuery] int count = 10)
        {
            var products = await _productService.GetNewReleasesAsync(count);
            return Ok(products);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId, [FromQuery] int count = 10)
        {
            var products = await _productService.GetProductsByCategoryAsync(categoryId, count);
            return Ok(products);
        }

        [HttpGet("author/{authorId}")]
        public async Task<IActionResult> GetProductsByAuthor(int authorId, [FromQuery] int count = 10)
        {
            var products = await _productService.GetProductsByAuthorAsync(authorId, count);
            return Ok(products);
        }

        [HttpGet("publisher/{publisherId}")]
        public async Task<IActionResult> GetProductsByPublisher(int publisherId, [FromQuery] int count = 10)
        {
            var products = await _productService.GetProductsByPublisherAsync(publisherId, count);
            return Ok(products);
        }

        [HttpPatch("{id}/stock")]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> UpdateProductStock(int id, [FromBody] UpdateStockDto updateStockDto)
        {
            var result = await _productService.UpdateProductStockAsync(id, updateStockDto.Quantity);
            if (!result)
                return NotFound();

            return Ok(new { message = "Stock updated successfully" });
        }

        [HttpGet("{id}/images")]
        public async Task<IActionResult> GetProductImages(int id)
        {
            var images = await _productService.GetProductImagesAsync(id);
            return Ok(images);
        }

        [HttpPost("images")]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> AddProductImage([FromBody] CreateProductImageDto createImageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var image = await _productService.AddProductImageAsync(createImageDto);
            if (image == null)
                return BadRequest(new { message = "Failed to add product image" });

            return Ok(image);
        }

        [HttpPost("upload-image")]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest(new { message = "No file was uploaded" });
                }

                // Validate file type
                var allowedTypes = new[] { "image/jpeg", "image/jpg", "image/png", "image/gif", "image/webp" };
                if (!allowedTypes.Contains(file.ContentType.ToLower()))
                {
                    return BadRequest(new { message = "Invalid file type. Only JPG, PNG, GIF, and WebP images are allowed." });
                }

                // Validate file size (5MB)
                if (file.Length > 5 * 1024 * 1024)
                {
                    return BadRequest(new { message = "File size too large. Maximum size is 5MB." });
                }

                // Ensure uploads directory exists
                var uploadsPath = Path.Combine(_environment.WebRootPath, "uploads", "products");
                if (!Directory.Exists(uploadsPath))
                {
                    Directory.CreateDirectory(uploadsPath);
                }

                // Generate unique filename
                var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
                var filePath = Path.Combine(uploadsPath, fileName);

                // Save file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Return the public URL - Force HTTPS in production
                var request = HttpContext.Request;
                var scheme = _environment.IsProduction() ? "https" : request.Scheme;
                var baseUrl = $"{scheme}://{request.Host}";
                var imageUrl = $"{baseUrl}/uploads/products/{fileName}";
                
                return Ok(new { 
                    message = "Image uploaded successfully", 
                    imageUrl = imageUrl,
                    fileName = fileName
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Image upload error: {ex.Message}");
                return BadRequest(new { message = "An error occurred while uploading the image" });
            }
        }

        [HttpPost("validate")]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> ValidateProductData([FromBody] CreateProductDto createProductDto)
        {
            var validationResults = new List<string>();

            try
            {
                // Check SKU uniqueness
                if (!string.IsNullOrEmpty(createProductDto.SKU))
                {
                    var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.SKU == createProductDto.SKU);
                    if (existingProduct != null)
                    {
                        validationResults.Add($"SKU '{createProductDto.SKU}' is already in use");
                    }
                }

                // Check foreign key references
                if (createProductDto.AuthorId.HasValue)
                {
                    var author = await _context.Authors.FindAsync(createProductDto.AuthorId.Value);
                    if (author == null)
                    {
                        validationResults.Add($"Author with ID {createProductDto.AuthorId.Value} not found");
                    }
                }

                if (createProductDto.PublisherId.HasValue)
                {
                    var publisher = await _context.Publishers.FindAsync(createProductDto.PublisherId.Value);
                    if (publisher == null)
                    {
                        validationResults.Add($"Publisher with ID {createProductDto.PublisherId.Value} not found");
                    }
                }

                if (createProductDto.CategoryId.HasValue)
                {
                    var category = await _context.Categories.FindAsync(createProductDto.CategoryId.Value);
                    if (category == null)
                    {
                        validationResults.Add($"Category with ID {createProductDto.CategoryId.Value} not found");
                    }
                }

                // Check required fields
                if (string.IsNullOrWhiteSpace(createProductDto.Title))
                {
                    validationResults.Add("Title is required");
                }

                if (string.IsNullOrWhiteSpace(createProductDto.ProductType))
                {
                    validationResults.Add("ProductType is required");
                }

                return Ok(new
                {
                    isValid = validationResults.Count == 0,
                    validationResults = validationResults,
                    data = createProductDto
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Validation failed", error = ex.Message });
            }
        }

        [HttpGet("reference-data")]
        public async Task<IActionResult> GetReferenceData()
        {
            try
            {
                var authors = await _context.Authors
                    .Where(a => a.IsActive)
                    .Select(a => new { a.Id, a.Name, a.NameArabic })
                    .OrderBy(a => a.Name)
                    .ToListAsync();

                var publishers = await _context.Publishers
                    .Select(p => new { p.Id, p.Name, p.NameArabic })
                    .OrderBy(p => p.Name)
                    .ToListAsync();

                var categories = await _context.Categories
                    .Where(c => c.IsActive)
                    .Select(c => new { c.Id, c.Name, c.NameArabic })
                    .OrderBy(c => c.Name)
                    .ToListAsync();

                return Ok(new
                {
                    authors = authors,
                    publishers = publishers,
                    categories = categories,
                    authorsCount = authors.Count,
                    publishersCount = publishers.Count,
                    categoriesCount = categories.Count
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Failed to load reference data", error = ex.Message });
            }
        }

        [HttpGet("types")]
        public IActionResult GetProductTypes()
        {
            var productTypes = new[]
            {
                new { Value = "Book", Label = "كتاب", LabelEnglish = "Book" },
                new { Value = "Stationery", Label = "قرطاسية", LabelEnglish = "Stationery" },
                new { Value = "Educational", Label = "مواد تعليمية", LabelEnglish = "Educational Materials" },
                new { Value = "Art", Label = "فنون", LabelEnglish = "Art Supplies" },
                new { Value = "Technology", Label = "تقنية", LabelEnglish = "Technology" },
                new { Value = "Other", Label = "أخرى", LabelEnglish = "Other" }
            };

            return Ok(productTypes);
        }

        [HttpGet("grades")]
        public IActionResult GetGrades()
        {
            var grades = new[]
            {
                new { Value = "KG1", Label = "روضة أولى", LabelEnglish = "KG1" },
                new { Value = "KG2", Label = "روضة ثانية", LabelEnglish = "KG2" },
                new { Value = "KG3", Label = "روضة ثالثة", LabelEnglish = "KG3" },
                new { Value = "1", Label = "الصف الأول", LabelEnglish = "Grade 1" },
                new { Value = "2", Label = "الصف الثاني", LabelEnglish = "Grade 2" },
                new { Value = "3", Label = "الصف الثالث", LabelEnglish = "Grade 3" },
                new { Value = "4", Label = "الصف الرابع", LabelEnglish = "Grade 4" },
                new { Value = "5", Label = "الصف الخامس", LabelEnglish = "Grade 5" },
                new { Value = "6", Label = "الصف السادس", LabelEnglish = "Grade 6" },
                new { Value = "7", Label = "الصف السابع", LabelEnglish = "Grade 7" },
                new { Value = "8", Label = "الصف الثامن", LabelEnglish = "Grade 8" },
                new { Value = "9", Label = "الصف التاسع", LabelEnglish = "Grade 9" },
                new { Value = "10", Label = "الصف العاشر", LabelEnglish = "Grade 10" },
                new { Value = "11", Label = "الصف الحادي عشر", LabelEnglish = "Grade 11" },
                new { Value = "12", Label = "الصف الثاني عشر", LabelEnglish = "Grade 12" },
                new { Value = "University", Label = "جامعي", LabelEnglish = "University" },
                new { Value = "General", Label = "عام", LabelEnglish = "General" }
            };

            return Ok(grades);
        }

        [HttpGet("subjects")]
        public IActionResult GetSubjects()
        {
            var subjects = new[]
            {
                new { Value = "Arabic", Label = "اللغة العربية", LabelEnglish = "Arabic" },
                new { Value = "English", Label = "اللغة الإنجليزية", LabelEnglish = "English" },
                new { Value = "Math", Label = "الرياضيات", LabelEnglish = "Mathematics" },
                new { Value = "Science", Label = "العلوم", LabelEnglish = "Science" },
                new { Value = "Social", Label = "الدراسات الاجتماعية", LabelEnglish = "Social Studies" },
                new { Value = "Islamic", Label = "التربية الإسلامية", LabelEnglish = "Islamic Education" },
                new { Value = "History", Label = "التاريخ", LabelEnglish = "History" },
                new { Value = "Geography", Label = "الجغرافيا", LabelEnglish = "Geography" },
                new { Value = "Art", Label = "الفنون", LabelEnglish = "Art" },
                new { Value = "Music", Label = "الموسيقى", LabelEnglish = "Music" },
                new { Value = "Physical", Label = "التربية البدنية", LabelEnglish = "Physical Education" },
                new { Value = "Computer", Label = "الحاسوب", LabelEnglish = "Computer Science" },
                new { Value = "Other", Label = "أخرى", LabelEnglish = "Other" }
            };

            return Ok(subjects);
        }
    }
}
