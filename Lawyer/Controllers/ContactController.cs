using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
    public class ContactController : Controller
    {
        PracticeAreaManager practiceAreaManager = new PracticeAreaManager(new EfPracticeAreaDal());
        public IActionResult Index()
        {
            var options = practiceAreaManager.GetAll();
            return PartialView(options);
        }
    }
}
