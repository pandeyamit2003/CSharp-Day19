using Microsoft.AspNetCore.Mvc;

namespace OnlineExamPortal.Controllers
{
    public class ExamController : Controller
    {
        private readonly ILogger<ExamController> _logger;

        public ExamController(ILogger<ExamController> logger)
        {
            _logger = logger;
        }

        // Login Session
        public IActionResult Login()
        {
            HttpContext.Session.SetString("StudentName", "Nitesh");

            _logger.LogInformation("Student Logged In");

            return Content("Session Created Successfully");
        }

        // Read Session
        public IActionResult Dashboard()
        {
            string name = HttpContext.Session.GetString("StudentName");

            return Content("Welcome " + name);
        }

        // Cookie Example
        public IActionResult SavePreference()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(7);

            Response.Cookies.Append("Theme", "Dark", options);

            return Content("Cookie Saved");
        }

        // Read Cookie
        public IActionResult GetPreference()
        {
            string theme = Request.Cookies["Theme"];

            return Content("Theme : " + theme);
        }
    }
}