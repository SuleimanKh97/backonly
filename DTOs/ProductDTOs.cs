using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace LibraryManagementAPI.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? TitleArabic { get; set; }
        public string? SKU { get; set; }
        public string? Description { get; set; }
        public string? DescriptionArabic { get; set; }
        public string ProductType { get; set; } = "Book";
        public int? AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public string? AuthorNameArabic { get; set; }
        public int? PublisherId { get; set; }
        public string? PublisherName { get; set; }
        public string? PublisherNameArabic { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryNameArabic { get; set; }
        public string? Grade { get; set; }
        public string? Subject { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int? Pages { get; set; }
        public string Language { get; set; } = "Arabic";
        public decimal? Price { get; set; }
        public decimal? OriginalPrice { get; set; }
        public int StockQuantity { get; set; }
        public string? CoverImageUrl { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsNewRelease { get; set; }
        public decimal Rating { get; set; }
        public int RatingCount { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<ProductImageDto> Images { get; set; } = new List<ProductImageDto>();
    }

    public class CreateProductDto
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [StringLength(200)]
        public string? TitleArabic { get; set; }

        [StringLength(20)]
        public string? SKU { get; set; }

        public string? Description { get; set; }

        public string? DescriptionArabic { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductType { get; set; } = "Book";

        public int? AuthorId { get; set; }

        public int? PublisherId { get; set; }

        public int? CategoryId { get; set; }

        public string? Grade { get; set; }

        public string? Subject { get; set; }

        public DateTime? PublicationDate { get; set; }

        public int? Pages { get; set; }

        [StringLength(20)]
        public string Language { get; set; } = "Arabic";

        public decimal? Price { get; set; }

        public decimal? OriginalPrice { get; set; }

        public int StockQuantity { get; set; } = 0;

        [StringLength(500)]
        public string? CoverImageUrl { get; set; }

        public List<CreateProductImageDto>? Images { get; set; }

        public bool IsAvailable { get; set; } = true;

        public bool IsFeatured { get; set; } = false;

        public bool IsNewRelease { get; set; } = false;
    }

    public class UpdateProductDto
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [StringLength(200)]
        public string? TitleArabic { get; set; }

        [StringLength(20)]
        public string? SKU { get; set; }

        public string? Description { get; set; }

        public string? DescriptionArabic { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductType { get; set; } = "Book";

        public int? AuthorId { get; set; }

        public int? PublisherId { get; set; }

        public int? CategoryId { get; set; }

        public string? Grade { get; set; }

        public string? Subject { get; set; }

        public DateTime? PublicationDate { get; set; }

        public int? Pages { get; set; }

        [StringLength(20)]
        public string Language { get; set; } = "Arabic";

        public decimal? Price { get; set; }

        public decimal? OriginalPrice { get; set; }

        public int StockQuantity { get; set; } = 0;

        [StringLength(500)]
        public string? CoverImageUrl { get; set; }

        public bool IsAvailable { get; set; } = true;

        public bool IsFeatured { get; set; } = false;

        public bool IsNewRelease { get; set; } = false;

        public List<UpdateProductImageDto>? Images { get; set; }
    }

    public class ProductSearchDto
    {
        public string? SearchTerm { get; set; }
        public string? ProductType { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }
        public int? PublisherId { get; set; }
        public string? Language { get; set; }
        public string? Grade { get; set; }
        public string? Subject { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? IsFeatured { get; set; }
        public bool? IsNewRelease { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string SortBy { get; set; } = "Title";
        public string SortOrder { get; set; } = "asc";
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class ProductImageDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string ImageType { get; set; } = "Gallery";
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateProductImageDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [StringLength(500)]
        public string ImageUrl { get; set; } = string.Empty;

        public string ImageType { get; set; } = "Gallery";

        public int DisplayOrder { get; set; } = 0;

        public bool IsActive { get; set; } = true;
    }

    public class UpdateProductImageDto
    {
        public int? Id { get; set; } // For existing images

        [Required]
        [StringLength(500)]
        public string ImageUrl { get; set; } = string.Empty;

        [StringLength(50)]
        public string ImageType { get; set; } = "Gallery";

        public int DisplayOrder { get; set; } = 0;

        public bool IsActive { get; set; } = true;
    }

    public class UpdateStockDto
    {
        [Required]
        public int Quantity { get; set; }
    }
}
