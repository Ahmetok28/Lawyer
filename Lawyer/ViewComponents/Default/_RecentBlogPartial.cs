using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
            
            return View(BlogViewModelConverter(_blogService.BringLatestBlogs(4).Data));
        }

        private List<RecentBlogViewModel> BlogViewModelConverter(List<Blog> blogViewModels)
        {

            List<RecentBlogViewModel> singleBlogViews = new List<RecentBlogViewModel>();
            foreach (var item in blogViewModels)
            {
                var model = new RecentBlogViewModel
                {
                    Id = item.BlogId,
                    Title = !string.IsNullOrEmpty(item.Title) && item.Title.Length > 20
                                          ? item.Title[..25]
                                          : item.Title,


                    ImageUrl = item.PhotoUrl,
                    CreatedDate = item.CreatedDate.ToString("dd MMMM yyyy"),
                   
                    


                };
                singleBlogViews.Add(model);
            }

            return singleBlogViews;
        }
    }
}
