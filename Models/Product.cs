using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [StringLength(200)]
        public string? TitleArabic { get; set; }

        [StringLength(20)]
        public string? SKU { get; set; } // Stock Keeping Unit instead of ISBN

        public string? Description { get; set; }

        public string? DescriptionArabic { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductType { get; set; } = "Book"; // Book, Stationery, etc.

        public int? AuthorId { get; set; } // Only for books

        public int? PublisherId { get; set; } // Only for books

        public int? CategoryId { get; set; }

        public string? Grade { get; set; } // For educational products

        public string? Subject { get; set; } // For educational products

        public DateTime? PublicationDate { get; set; } // Only for books

        public int? Pages { get; set; } // Only for books

        [StringLength(20)]
        public string Language { get; set; } = "Arabic";

        [Column(TypeName = "decimal(10,2)")]
        public decimal? Price { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? OriginalPrice { get; set; }

        public int StockQuantity { get; set; } = 0;

        [StringLength(500)]
        public string? CoverImageUrl { get; set; }

        public bool IsAvailable { get; set; } = true;

        public bool IsFeatured { get; set; } = false;

        public bool IsNewRelease { get; set; } = false;

        [Column(TypeName = "decimal(3,2)")]
        public decimal Rating { get; set; } = 0.0m;

        public int RatingCount { get; set; } = 0;

        public int ViewCount { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual Author? Author { get; set; }
        public virtual Publisher? Publisher { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    }
}
