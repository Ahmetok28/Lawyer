using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
    
    public class BlogCommentController : Controller
    {
        private readonly IBlogCommentService _commentService;

        public BlogCommentController(IBlogCommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(BlogComment comment)
        {
            comment.CommentDate = Convert.ToDateTime(DateTime.Now);
            comment.CommentStatus = true;
            _commentService.Add(comment);
           // var updatedComments = _commentService.BlogCommentsGetAllByBlogId(comment.BlogId).Data;
            return RedirectToAction("SingleBlog", "Blog", new {id=comment.BlogId});
        }
    }
}
