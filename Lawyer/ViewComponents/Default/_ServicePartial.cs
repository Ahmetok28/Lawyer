using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _ServicePartial : ViewComponent
    {
        PracticeAreaManager practiceAreaManager = new PracticeAreaManager(new EfPracticeAreaDal());
        public IViewComponentResult Invoke()
        {
            var values = practiceAreaManager.GetAll();
        
            return View(values);
        }
    }
}
