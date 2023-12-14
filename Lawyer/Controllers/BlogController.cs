using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SingleBlog()
        {
            return View();
        }
    }
}
