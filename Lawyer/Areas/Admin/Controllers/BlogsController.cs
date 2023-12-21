using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogsController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var values=_blogService.GetAll();
            return View(values);
        }

        public IActionResult Edit(int id)
        {
            return View();
        }
        public IActionResult Details()
        {
            var values = _blogService.GetAll();
            return View(values);
        }
    }
}
