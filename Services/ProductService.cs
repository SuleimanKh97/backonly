using Microsoft.EntityFrameworkCore;
using LibraryManagementAPI.Data;
using LibraryManagementAPI.DTOs;
using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly LibraryDbContext _context;

        public ProductService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync(ProductSearchDto searchDto)
        {
            var query = _context.Products
                .Include(p => p.Author)
                .Include(p => p.Publisher)
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .AsQueryable();

            // Apply filters
            if (!string.IsNullOrEmpty(searchDto.SearchTerm))
            {
                query = query.Where(p => 
                    p.Title.Contains(searchDto.SearchTerm) || 
                    p.TitleArabic!.Contains(searchDto.SearchTerm) ||
                    p.Description!.Contains(searchDto.SearchTerm) ||
                    p.DescriptionArabic!.Contains(searchDto.SearchTerm) ||
                    p.SKU!.Contains(searchDto.SearchTerm));
            }

            if (!string.IsNullOrEmpty(searchDto.ProductType))
            {
                query = query.Where(p => p.ProductType == searchDto.ProductType);
            }

            if (searchDto.CategoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == searchDto.CategoryId);
            }

            if (searchDto.AuthorId.HasValue)
            {
                query = query.Where(p => p.AuthorId == searchDto.AuthorId);
            }

            if (searchDto.PublisherId.HasValue)
            {
                query = query.Where(p => p.PublisherId == searchDto.PublisherId);
            }

            if (!string.IsNullOrEmpty(searchDto.Language))
            {
                query = query.Where(p => p.Language == searchDto.Language);
            }

            if (!string.IsNullOrEmpty(searchDto.Grade))
            {
                query = query.Where(p => p.Grade == searchDto.Grade);
            }

            if (!string.IsNullOrEmpty(searchDto.Subject))
            {
                query = query.Where(p => p.Subject == searchDto.Subject);
            }

            if (searchDto.IsAvailable.HasValue)
            {
                query = query.Where(p => p.IsAvailable == searchDto.IsAvailable);
            }

            if (searchDto.IsFeatured.HasValue)
            {
                query = query.Where(p => p.IsFeatured == searchDto.IsFeatured);
            }

            if (searchDto.IsNewRelease.HasValue)
            {
                query = query.Where(p => p.IsNewRelease == searchDto.IsNewRelease);
            }

            if (searchDto.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= searchDto.MinPrice);
            }

            if (searchDto.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= searchDto.MaxPrice);
            }

            // Apply sorting
            query = searchDto.SortBy.ToLower() switch
            {
                "title" => searchDto.SortOrder.ToLower() == "desc" 
                    ? query.OrderByDescending(p => p.Title) 
                    : query.OrderBy(p => p.Title),
                "price" => searchDto.SortOrder.ToLower() == "desc" 
                    ? query.OrderByDescending(p => p.Price) 
                    : query.OrderBy(p => p.Price),
                "createdat" => searchDto.SortOrder.ToLower() == "desc" 
                    ? query.OrderByDescending(p => p.CreatedAt) 
                    : query.OrderBy(p => p.CreatedAt),
                "rating" => searchDto.SortOrder.ToLower() == "desc" 
                    ? query.OrderByDescending(p => p.Rating) 
                    : query.OrderBy(p => p.Rating),
                _ => query.OrderBy(p => p.Title)
            };

            // Apply pagination
            var totalCount = await query.CountAsync();
            var products = await query
                .Skip((searchDto.Page - 1) * searchDto.PageSize)
                .Take(searchDto.PageSize)
                .ToListAsync();

            return products.Select(MapToDto);
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.Author)
                .Include(p => p.Publisher)
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id);

            return product != null ? MapToDto(product) : null;
        }

        public async Task<ProductDto?> CreateProductAsync(CreateProductDto createProductDto)
        {
            try
            {
                Console.WriteLine($"Starting product creation with data: {System.Text.Json.JsonSerializer.Serialize(createProductDto)}");

                // Check if SKU already exists (if provided)
                if (!string.IsNullOrEmpty(createProductDto.SKU))
                {
                    var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.SKU == createProductDto.SKU);
                    if (existingProduct != null)
                    {
                        throw new Exception($"A product with SKU '{createProductDto.SKU}' already exists.");
                    }
                }

                // Check if foreign key references exist (only for books)
                if (createProductDto.ProductType == "Book")
                {
                    if (createProductDto.AuthorId.HasValue)
                    {
                        var author = await _context.Authors.FindAsync(createProductDto.AuthorId.Value);
                        if (author == null)
                        {
                            throw new Exception($"Author with ID {createProductDto.AuthorId.Value} not found.");
                        }
                        Console.WriteLine($"Author found: {author.Name}");
                    }

                    if (createProductDto.PublisherId.HasValue)
                    {
                        var publisher = await _context.Publishers.FindAsync(createProductDto.PublisherId.Value);
                        if (publisher == null)
                        {
                            throw new Exception($"Publisher with ID {createProductDto.PublisherId.Value} not found.");
                        }
                        Console.WriteLine($"Publisher found: {publisher.Name}");
                    }
                }

                if (createProductDto.CategoryId.HasValue)
                {
                    var category = await _context.Categories.FindAsync(createProductDto.CategoryId.Value);
                    if (category == null)
                    {
                        throw new Exception($"Category with ID {createProductDto.CategoryId.Value} not found.");
                    }
                    Console.WriteLine($"Category found: {category.Name}");
                }

                var product = new Product
                {
                    Title = createProductDto.Title,
                    TitleArabic = createProductDto.TitleArabic,
                    SKU = createProductDto.SKU,
                    Description = createProductDto.Description,
                    DescriptionArabic = createProductDto.DescriptionArabic,
                    ProductType = createProductDto.ProductType,
                    AuthorId = createProductDto.AuthorId,
                    PublisherId = createProductDto.PublisherId,
                    CategoryId = createProductDto.CategoryId,
                    Grade = createProductDto.Grade,
                    Subject = createProductDto.Subject,
                    PublicationDate = createProductDto.PublicationDate,
                    Pages = createProductDto.Pages,
                    Language = createProductDto.Language,
                    Price = createProductDto.Price,
                    OriginalPrice = createProductDto.OriginalPrice,
                    StockQuantity = createProductDto.StockQuantity,
                    CoverImageUrl = createProductDto.CoverImageUrl,
                    IsAvailable = createProductDto.IsAvailable,
                    IsFeatured = createProductDto.IsFeatured,
                    IsNewRelease = createProductDto.IsNewRelease,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                Console.WriteLine($"Product object created: {System.Text.Json.JsonSerializer.Serialize(product)}");

                _context.Products.Add(product);
                Console.WriteLine("Product added to context");

                try
                {
                    await _context.SaveChangesAsync();
                    Console.WriteLine("Product saved successfully");

                    // Reload the product with navigation properties
                    var savedProduct = await _context.Products
                        .Include(p => p.Author)
                        .Include(p => p.Publisher)
                        .Include(p => p.Category)
                        .Include(p => p.ProductImages)
                        .FirstOrDefaultAsync(p => p.Id == product.Id);

                    return savedProduct != null ? MapToDto(savedProduct) : null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Database save failed: {ex.Message}");
                    throw new Exception($"Failed to create product: Database save failed: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Product creation error: {ex.Message}");
                throw;
            }
        }

        public async Task<ProductDto?> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return null;

            // Update properties
            product.Title = updateProductDto.Title;
            product.TitleArabic = updateProductDto.TitleArabic;
            product.SKU = updateProductDto.SKU;
            product.Description = updateProductDto.Description;
            product.DescriptionArabic = updateProductDto.DescriptionArabic;
            product.ProductType = updateProductDto.ProductType;
            product.AuthorId = updateProductDto.AuthorId;
            product.PublisherId = updateProductDto.PublisherId;
            product.CategoryId = updateProductDto.CategoryId;
            product.Grade = updateProductDto.Grade;
            product.Subject = updateProductDto.Subject;
            product.PublicationDate = updateProductDto.PublicationDate;
            product.Pages = updateProductDto.Pages;
            product.Language = updateProductDto.Language;
            product.Price = updateProductDto.Price;
            product.OriginalPrice = updateProductDto.OriginalPrice;
            product.StockQuantity = updateProductDto.StockQuantity;
            product.CoverImageUrl = updateProductDto.CoverImageUrl;
            product.IsAvailable = updateProductDto.IsAvailable;
            product.IsFeatured = updateProductDto.IsFeatured;
            product.IsNewRelease = updateProductDto.IsNewRelease;
            product.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return await GetProductByIdAsync(id);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProductDto>> GetFeaturedProductsAsync(int count = 10)
        {
            var products = await _context.Products
                .Include(p => p.Author)
                .Include(p => p.Publisher)
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Where(p => p.IsFeatured && p.IsAvailable)
                .OrderByDescending(p => p.CreatedAt)
                .Take(count)
                .ToListAsync();

            return products.Select(MapToDto);
        }

        public async Task<IEnumerable<ProductDto>> GetNewReleasesAsync(int count = 10)
        {
            var products = await _context.Products
                .Include(p => p.Author)
                .Include(p => p.Publisher)
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Where(p => p.IsNewRelease && p.IsAvailable)
                .OrderByDescending(p => p.CreatedAt)
                .Take(count)
                .ToListAsync();

            return products.Select(MapToDto);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId, int count = 10)
        {
            var products = await _context.Products
                .Include(p => p.Author)
                .Include(p => p.Publisher)
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Where(p => p.CategoryId == categoryId && p.IsAvailable)
                .OrderByDescending(p => p.CreatedAt)
                .Take(count)
                .ToListAsync();

            return products.Select(MapToDto);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByAuthorAsync(int authorId, int count = 10)
        {
            var products = await _context.Products
                .Include(p => p.Author)
                .Include(p => p.Publisher)
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Where(p => p.AuthorId == authorId && p.IsAvailable)
                .OrderByDescending(p => p.CreatedAt)
                .Take(count)
                .ToListAsync();

            return products.Select(MapToDto);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByPublisherAsync(int publisherId, int count = 10)
        {
            var products = await _context.Products
                .Include(p => p.Author)
                .Include(p => p.Publisher)
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Where(p => p.PublisherId == publisherId && p.IsAvailable)
                .OrderByDescending(p => p.CreatedAt)
                .Take(count)
                .ToListAsync();

            return products.Select(MapToDto);
        }

        public async Task<bool> UpdateProductStockAsync(int id, int quantity)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;

            product.StockQuantity = quantity;
            product.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProductImageDto>> GetProductImagesAsync(int id)
        {
            var images = await _context.ProductImages
                .Where(pi => pi.ProductId == id && pi.IsActive)
                .OrderBy(pi => pi.DisplayOrder)
                .ToListAsync();

            return images.Select(MapToImageDto);
        }

        public async Task<ProductImageDto?> AddProductImageAsync(CreateProductImageDto createImageDto)
        {
            var product = await _context.Products.FindAsync(createImageDto.ProductId);
            if (product == null)
                return null;

            var image = new ProductImage
            {
                ProductId = createImageDto.ProductId,
                ImageUrl = createImageDto.ImageUrl,
                ImageType = createImageDto.ImageType,
                DisplayOrder = createImageDto.DisplayOrder,
                IsActive = createImageDto.IsActive,
                CreatedAt = DateTime.UtcNow
            };

            _context.ProductImages.Add(image);
            await _context.SaveChangesAsync();

            return MapToImageDto(image);
        }

        public async Task IncrementViewCountAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.ViewCount++;
                await _context.SaveChangesAsync();
            }
        }

        private static ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Title = product.Title,
                TitleArabic = product.TitleArabic,
                SKU = product.SKU,
                Description = product.Description,
                DescriptionArabic = product.DescriptionArabic,
                ProductType = product.ProductType,
                AuthorId = product.AuthorId,
                AuthorName = product.Author?.Name,
                AuthorNameArabic = product.Author?.NameArabic,
                PublisherId = product.PublisherId,
                PublisherName = product.Publisher?.Name,
                PublisherNameArabic = product.Publisher?.NameArabic,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name,
                CategoryNameArabic = product.Category?.NameArabic,
                Grade = product.Grade,
                Subject = product.Subject,
                PublicationDate = product.PublicationDate,
                Pages = product.Pages,
                Language = product.Language,
                Price = product.Price,
                OriginalPrice = product.OriginalPrice,
                StockQuantity = product.StockQuantity,
                CoverImageUrl = product.CoverImageUrl,
                IsAvailable = product.IsAvailable,
                IsFeatured = product.IsFeatured,
                IsNewRelease = product.IsNewRelease,
                Rating = product.Rating,
                RatingCount = product.RatingCount,
                ViewCount = product.ViewCount,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                Images = product.ProductImages.Select(MapToImageDto).ToList()
            };
        }

        private static ProductImageDto MapToImageDto(ProductImage image)
        {
            return new ProductImageDto
            {
                Id = image.Id,
                ProductId = image.ProductId,
                ImageUrl = image.ImageUrl,
                ImageType = image.ImageType,
                DisplayOrder = image.DisplayOrder,
                IsActive = image.IsActive,
                CreatedAt = image.CreatedAt
            };
        }
    }
}
