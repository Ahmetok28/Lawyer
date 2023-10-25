using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
    public class PartialController : Controller
    {
        PracticeAreaManager practiceAreaManager = new PracticeAreaManager(new EfPracticeAreaDal());
        public PartialViewResult NavbarPartial()
        {
            var value = practiceAreaManager.GetTitleAndId();
            return PartialView(value);
        }
    }
}
