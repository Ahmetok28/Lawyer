using Business.Abstract;
using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Areas.Admin.ViewComponents.Default
{
    public class _HeaderPartialAdmin : ViewComponent
    {
        IHomeTextService _homeTextService;

        public _HeaderPartialAdmin(IHomeTextService homeTextService)
        {
            _homeTextService = homeTextService;
        }

       
        public IViewComponentResult Invoke()
        {
            var value = _homeTextService.GetHomeText().Data;
            return View(value);
        }
    }
}
