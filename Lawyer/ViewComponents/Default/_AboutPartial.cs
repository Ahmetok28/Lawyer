using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _AboutPartial : ViewComponent
    {
        AboutTextManager textManager = new AboutTextManager(new EfAboutTextDal());
        public IViewComponentResult Invoke()
        {
            var value = textManager.GetAboutText();
            return View(value);
        }
    }
}
