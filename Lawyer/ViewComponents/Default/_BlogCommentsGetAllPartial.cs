using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _BlogCommentsGetAllPartial : ViewComponent
    {
        private readonly IBlogCommentService _blogCommentService;

        public _BlogCommentsGetAllPartial(IBlogCommentService blogCommentService)
        {
            _blogCommentService = blogCommentService;
        }

        public IViewComponentResult Invoke(int blogId)
        {
            var values = _blogCommentService.BlogCommentsGetAllByBlogId(blogId).Data;
            ViewBag.v1=values;
            return View(values);
        }
    }
   
}
