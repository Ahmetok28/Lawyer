using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Route("Admin/[controller]/[action]/{id?}")]
    public class BlogCategoriesController : Controller
    {
        private readonly IBlogCategoryService _blogCategoryService;

        public BlogCategoriesController(IBlogCategoryService blogCategoryService)
        {
            _blogCategoryService = blogCategoryService;
        }

        public IActionResult Index()
        {
            var value = _blogCategoryService.GetAll().Data;
            return View(value);
        }
        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(BlogCategory blogCategory) 
        {
            _blogCategoryService.Add(blogCategory);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
          
            return View(_blogCategoryService.BlogCategoryGetById(id).Data);
        }
        [HttpPost]
        public IActionResult Edit(BlogCategory blogCategory) 
        {
            _blogCategoryService.Update(blogCategory);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id) 
        {
            return View(_blogCategoryService.BlogCategoryGetById(id).Data);
        }
        [HttpPost]
        public IActionResult Delete(BlogCategory blogCategory) 
        {
            _blogCategoryService.Delete(blogCategory);
            return RedirectToAction("Index");
        }

    }
}
