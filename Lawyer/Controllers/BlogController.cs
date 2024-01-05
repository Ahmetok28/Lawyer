using Business.Abstract;
using Entities.DTOs;
using Lawyer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index(int categoryid)
        {

            if (categoryid == 0)
            {
                return View(BlogViewModelConverter(_blogService.GetAllBlogDetails().Data));
            }
            if (categoryid!=0)
            {
                return View(BlogViewModelConverter(_blogService.GetBlogDetailsByCategoryId(categoryid).Data));
            }
            
            return View();
        }

        public IActionResult SingleBlog(int id)
        {
            
            return View(_blogService.GetBlogDetailsById(id).Data);
        }
        
     

        private List<BlogViewModel> BlogViewModelConverter(List<BlogDTO> blogViewModels)
        {

            List<BlogViewModel> singleBlogViews = new List<BlogViewModel>();
            foreach (var item in blogViewModels)
            {
                var model = new BlogViewModel
                {
                    Id = item.BlogId,
                    Title = item.BlogTitle,
                    Description = !string.IsNullOrEmpty(item.BlogDescription) && item.BlogDescription.Length > 200
                                          ? item.BlogDescription[..350]
                                          : item.BlogDescription,
                    Author = item.AuthorFullName,
                    ImageUrl = item.BlogPhoto,
                    CreatedDateDays = item.BlogCreatedDate.ToString("dd"),
                    CreatedDateMonths = item.BlogCreatedDate.ToString("MMM"),


                };
                singleBlogViews.Add(model);
            }

            return singleBlogViews;
        }

    }
}
