using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Lawyer.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin,Yazar")]
    public class BlogsController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly IUserService _userService;


        public BlogsController(IBlogService blogService, IBlogCategoryService blogCategoryService, IUserService userService)
        {
            _blogService = blogService;
            _blogCategoryService = blogCategoryService;
            _userService = userService;
        }

        
        public IActionResult Index(int categoryId, int authhorId)
        {
            ViewBag.Categories = _blogCategoryService.GetAll().Data;
            ViewBag.Authors = _userService.GetAuthors().Data;

            if (categoryId==0 && authhorId==0)
            {
                var values =  _blogService.GetAllBlogDetails().Data;
               
                return  View(values);
            }
            else if (categoryId != 0 && authhorId == 0)
            {
                var values=_blogService.GetBlogDetailsByCategoryId(categoryId).Data;
                return View(values) ;
            }
            else if(categoryId == 0 && authhorId != 0)
            {
                var values= _blogService.GetBlogDetailsByAuthorId(authhorId).Data;
                return View(values) ;
            }
            else if (categoryId != 0 && authhorId != 0)
            {
                var values=_blogService.GetBlogDetailsByCategoryAndAuthorId(categoryId, authhorId).Data;
                return View(values);
            }
            return View();
               
        }

       
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.v1 = _blogCategoryService.GetAll().Data;
            return View();
        }
       
        [HttpPost]
        public IActionResult Add(IFormFile image, Blog blog)
        {
            blog.CreatedDate = DateTime.Now;
            string userId =User.FindFirstValue(ClaimTypes.NameIdentifier);
            blog.AuthorId= Convert.ToInt32(userId);
            _blogService.Add(image,blog);            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var blogValue=_blogService.BlogGetById(id).Data;
            var blogCategories = _blogCategoryService.GetAll().Data;
            ViewBag.createdDate = blogValue.CreatedDate.ToString("yyyy/mm/dd");
            var model= Tuple.Create(blogValue, blogCategories);
        
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(IFormFile image, Blog blog)
        {
           

                 _blogService.Update(image,blog);
                
                return RedirectToAction("Index");
          
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result= _blogService.BlogGetById(id);
            if(result.Success)
            {
                return View(result.Data);
            }
            return BadRequest();
        }  
        [HttpPost]
        public IActionResult Delete(Blog blog)
        {
            
            var result= _blogService.Delete(blog);
            if(result.Success)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var values = _blogService.GetBlogDetailsById(id).Data;
            return View(values);
        }
    }
}
