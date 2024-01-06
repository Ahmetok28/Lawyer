using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Lawyer.Helpers;
using Lawyer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _RecentBlogPartial : ViewComponent
    {
        private readonly IBlogService _blogService;

        public _RecentBlogPartial(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            
            return View(BlogTitleConverterHelper.ConvertToBlogViewModel(_blogService.BringLatestBlogs(4).Data,25));
        }

       
    }
}
