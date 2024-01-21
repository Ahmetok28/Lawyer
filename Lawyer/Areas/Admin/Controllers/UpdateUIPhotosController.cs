using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Areas.Admin.Controllers
{
    public class UpdateUIPhotosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HomePageHeaderPhoto([FromForm] IFormFile file)
        {
            return View();
        }
    }
}
