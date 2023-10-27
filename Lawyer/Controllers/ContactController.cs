using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
    public class ContactController : Controller
    {
        ContactPageManager contactPageManager = new ContactPageManager(new EfContactPageDal());
        public IActionResult Index()
        {
            var options = contactPageManager.GetContactPage();
            return PartialView(options);
        }
    }
}
