using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _BlogCategoryPartial : ViewComponent
    {
        private readonly IBlogCategoryService _blogCategoryService;

        public _BlogCategoryPartial(IBlogCategoryService blogCategoryService)
        {
            _blogCategoryService = blogCategoryService;
        }

        public IViewComponentResult Invoke()
        {
            
            return View(_blogCategoryService.GetAll().Data);
        }
    }
}
