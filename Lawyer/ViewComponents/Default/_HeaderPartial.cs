using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _HeaderPartial : ViewComponent
    {
        HomeTextManager homeTextManager = new HomeTextManager(new EfHomeTextDal());
        public IViewComponentResult Invoke()
        {
            var value = homeTextManager.GetHomeText();
            return View(value);
        }
    }
}
