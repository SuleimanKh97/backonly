using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementAPI.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public AnalyticsController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: api/Analytics/overview
        [HttpGet("overview")]
        public async Task<IActionResult> GetOverview()
        {
            var totalProducts = await _context.Products.CountAsync();
            var availableProducts = await _context.Products.CountAsync(p => p.IsAvailable);
            var totalCategories = await _context.Categories.CountAsync();
            var totalAuthors = await _context.Authors.CountAsync();
            var totalPublishers = await _context.Publishers.CountAsync();

            return Ok(new
            {
                totalProducts,
                availableProducts,
                totalCategories,
                totalAuthors,
                totalPublishers
            });
        }

        // GET: api/Analytics/products-by-category
        [HttpGet("products-by-category")]
        public async Task<IActionResult> GetProductsByCategory()
        {
            var data = await _context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    categoryArabic = c.NameArabic,
                    count = c.Books.Count()
                })
                .OrderByDescending(x => x.count)
                .ToListAsync();

            return Ok(data);
        }

        // GET: api/Analytics/products-by-type
        [HttpGet("products-by-type")]
        public async Task<IActionResult> GetProductsByType()
        {
            var data = await _context.Products
                .GroupBy(p => p.ProductType)
                .Select(g => new
                {
                    type = g.Key,
                    count = g.Count()
                })
                .OrderByDescending(x => x.count)
                .ToListAsync();

            return Ok(data);
        }

        // GET: api/Analytics/products-by-language
        [HttpGet("products-by-language")]
        public async Task<IActionResult> GetProductsByLanguage()
        {
            var data = await _context.Products
                .GroupBy(p => p.Language)
                .Select(g => new
                {
                    language = g.Key ?? "Not Specified",
                    count = g.Count()
                })
                .OrderByDescending(x => x.count)
                .ToListAsync();

            return Ok(data);
        }

        // GET: api/Analytics/stock-status
        [HttpGet("stock-status")]
        public async Task<IActionResult> GetStockStatus()
        {
            var inStock = await _context.Products.CountAsync(p => p.StockQuantity > 0);
            var outOfStock = await _context.Products.CountAsync(p => p.StockQuantity == 0);
            var lowStock = await _context.Products.CountAsync(p => p.StockQuantity > 0 && p.StockQuantity <= 5);

            return Ok(new
            {
                inStock,
                outOfStock,
                lowStock,
                total = inStock + outOfStock
            });
        }

        // GET: api/Analytics/featured-products
        [HttpGet("featured-products")]
        public async Task<IActionResult> GetFeaturedProducts()
        {
            var featured = await _context.Products.CountAsync(p => p.IsFeatured);
            var newReleases = await _context.Products.CountAsync(p => p.IsNewRelease);
            var available = await _context.Products.CountAsync(p => p.IsAvailable);

            return Ok(new
            {
                featured,
                newReleases,
                available
            });
        }

        // GET: api/Analytics/recent-activity
        [HttpGet("recent-activity")]
        public async Task<IActionResult> GetRecentActivity()
        {
            var recentProducts = await _context.Products
                .OrderByDescending(p => p.CreatedAt)
                .Take(10)
                .Select(p => new
                {
                    id = p.Id,
                    title = p.Title,
                    titleArabic = p.TitleArabic,
                    createdAt = p.CreatedAt,
                    isAvailable = p.IsAvailable
                })
                .ToListAsync();

            return Ok(recentProducts);
        }

        // GET: api/Analytics/grade-distribution
        [HttpGet("grade-distribution")]
        public async Task<IActionResult> GetGradeDistribution()
        {
            var data = await _context.Products
                .Where(p => !string.IsNullOrEmpty(p.Grade))
                .GroupBy(p => p.Grade)
                .Select(g => new
                {
                    grade = g.Key,
                    count = g.Count()
                })
                .OrderBy(x => x.grade)
                .ToListAsync();

            return Ok(data);
        }

        // GET: api/Analytics/subject-distribution
        [HttpGet("subject-distribution")]
        public async Task<IActionResult> GetSubjectDistribution()
        {
            var data = await _context.Products
                .Where(p => !string.IsNullOrEmpty(p.Subject))
                .GroupBy(p => p.Subject)
                .Select(g => new
                {
                    subject = g.Key,
                    count = g.Count()
                })
                .OrderByDescending(x => x.count)
                .Take(10)
                .ToListAsync();

            return Ok(data);
        }

        // GET: api/Analytics/price-ranges
        [HttpGet("price-ranges")]
        public async Task<IActionResult> GetPriceRanges()
        {
            var products = await _context.Products
                .Where(p => p.Price.HasValue)
                .Select(p => p.Price!.Value)
                .ToListAsync();

            var ranges = new[]
            {
                new { range = "0-5", min = 0m, max = 5m, count = products.Count(p => p >= 0 && p < 5) },
                new { range = "5-10", min = 5m, max = 10m, count = products.Count(p => p >= 5 && p < 10) },
                new { range = "10-20", min = 10m, max = 20m, count = products.Count(p => p >= 10 && p < 20) },
                new { range = "20-50", min = 20m, max = 50m, count = products.Count(p => p >= 20 && p < 50) },
                new { range = "50+", min = 50m, max = decimal.MaxValue, count = products.Count(p => p >= 50) }
            };

            return Ok(ranges.Where(r => r.count > 0));
        }
    }
}
