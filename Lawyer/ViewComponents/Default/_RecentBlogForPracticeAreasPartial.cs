using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _RecentBlogForPracticeAreasPartial : ViewComponent
    {
        private readonly IBlogService _blogService;

        public _RecentBlogForPracticeAreasPartial(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
           
          
            return View(_blogService.BringLatestBlogsDetails(3).Data);
        }


    }
}
