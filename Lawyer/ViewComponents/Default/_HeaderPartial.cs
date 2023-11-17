using Business.Abstract;
using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _HeaderPartial : ViewComponent
    {
        IHomeTextService _homeTextService;

        public _HeaderPartial(IHomeTextService homeTextService)
        {
            _homeTextService = homeTextService;
        }

       
        public IViewComponentResult Invoke()
        {
            var value = _homeTextService.GetHomeText();
            return View(value);
        }
    }
}
