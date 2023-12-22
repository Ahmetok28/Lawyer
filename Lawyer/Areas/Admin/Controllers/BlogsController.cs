using Business.Abstract;
using Entities.Concrete;
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value=_blogService.BlogGetById(1);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
          _blogService.Update(blog);
            return View("ok");
        }
        public IActionResult Details()
        {
            var values = _blogService.GetAll();
            return View(values);
        }
    }
}
