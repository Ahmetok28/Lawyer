using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
    public class ErrorPagesController : Controller
    {
        public IActionResult PageNotFound(int code)
        {
            return View();
        }
    }
}
