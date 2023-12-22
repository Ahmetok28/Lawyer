using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _AboutPartial : ViewComponent
    {
        IAboutTextService _aboutTextService;

        public _AboutPartial(IAboutTextService abouttextService)
        {
            _aboutTextService = abouttextService;
        }

       
        public IViewComponentResult Invoke()
        {
            var value = _aboutTextService.GetAboutText().Data;
            return View(value);
        }
    }
}
