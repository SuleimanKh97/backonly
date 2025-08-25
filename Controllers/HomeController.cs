using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementAPI.Data;

namespace LibraryManagementAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                message = "Welcome to Royal Study Library Management API",
                version = "1.0.0",
                status = "Running",
                documentation = "/swagger",
                endpoints = new
                {
                    auth = "/api/auth",
                    books = "/api/books",
                    categories = "/api/categories",
                    authors = "/api/authors",
                    publishers = "/api/publishers",
                    quizzes = "/api/quizzes",
                    studyMaterials = "/api/study-materials",
                    studySchedules = "/api/study-schedules",
                    studyTips = "/api/study-tips",
                    bookInquiries = "/api/book-inquiries",
                    dashboard = "/api/dashboard"
                }
            });
        }

        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok(new
            {
                status = "Healthy",
                timestamp = DateTime.UtcNow,
                environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"
            });
        }

        [HttpGet("test-db")]
        public async Task<IActionResult> TestDatabase()
        {
            try
            {
                var context = HttpContext.RequestServices.GetRequiredService<LibraryDbContext>();
                
                // Test basic connection
                var bookCount = await context.Books.CountAsync();
                var authorCount = await context.Authors.CountAsync();
                var publisherCount = await context.Publishers.CountAsync();
                var categoryCount = await context.Categories.CountAsync();

                return Ok(new
                {
                    message = "Database connection successful",
                    counts = new
                    {
                        books = bookCount,
                        authors = authorCount,
                        publishers = publisherCount,
                        categories = categoryCount
                    },
                    timestamp = DateTime.UtcNow
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Database connection failed",
                    error = ex.Message,
                    stackTrace = ex.StackTrace
                });
            }
        }
    }
}
