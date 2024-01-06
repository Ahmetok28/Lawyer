using Business.Abstract;
using Lawyer.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _LastPrevBlogPartial : ViewComponent
    {
        private readonly IBlogService _blogService;

        public _LastPrevBlogPartial(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke(int id)
        {
            
            return View(BlogTitleConverterHelper.ConvertToBlogViewModel(_blogService.PrevAndNextBlogs(id).Data,43));
        }

       
    }
}
