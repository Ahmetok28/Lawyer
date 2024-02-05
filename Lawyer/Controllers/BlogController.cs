using Business.Abstract;
using Entities.DTOs;
using Lawyer.Helpers;
using Lawyer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
   
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IBlogCommentService _blogCommentService;

        public BlogController(IBlogService blogService, IBlogCommentService blogCommentService)
        {
            _blogService = blogService;
            _blogCommentService = blogCommentService;
        }

        public IActionResult Index( int categoryid, string ara="", int pageNumber = 1)
        {
            List<BlogViewModel> blogs;
            int pageSize = 4;

            if (categoryid == 0)
            {
                blogs = BlogViewModelConverter(_blogService.GetAllBlogDetails().Data);
            }
            else
            {
                blogs = BlogViewModelConverter(_blogService.GetBlogDetailsByCategoryId(categoryid).Data);
            }

            if (!string.IsNullOrEmpty(ara))
            {                var normalizedSearchString = ara.ToLowerInvariant();
                blogs = blogs
              .Where(b => HtmlUtilities.StripHtml(b.Title).ToLowerInvariant().Contains(normalizedSearchString) ||
                          HtmlUtilities.StripHtml(b.Content).ToLowerInvariant().Contains(normalizedSearchString) ||
                          HtmlUtilities.StripHtml(b.DescriptionForSearch).ToLowerInvariant().Contains(normalizedSearchString))
              .ToList();

            }

            // Sayfalama işlemleri
            var pagedBlogs = blogs.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            // ViewBag veya ViewData kullanarak sayfalama bilgilerini view'e iletebilirsiniz.
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItems = blogs.Count;
            ViewBag.TotalPages = Math.Ceiling((double)blogs.Count / pageSize);

            return View(pagedBlogs);
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
                    AuthorId=item.AuthorId,
                    Title = item.BlogTitle,
                    Description = !string.IsNullOrEmpty(item.BlogDescription) && item.BlogDescription.Length > 200
                                          ? item.BlogDescription[..350]
                                          : item.BlogDescription,
                    DescriptionForSearch= item.BlogDescription,
                    Content= item.BlogContent,
                    Author = item.AuthorFullName,
                    ImageUrl = item.BlogPhoto,
                    SeoUrl=item.SeoUrl,
                    AuthorSeoUrl=item.AuthorSeoUrl,
                    CreatedDateDays = item.BlogCreatedDate.ToString("dd"),
                    CreatedDateMonths = item.BlogCreatedDate.ToString("MMM"),


                };
                singleBlogViews.Add(model);
            }

            return singleBlogViews;
        }

    }
}
