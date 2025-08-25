using Microsoft.AspNetCore.Mvc;

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
    }
}
