using Business.Abstract;
using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
    public class ContactController : Controller
    {
        IContactPageService _contactPageService;

        public ContactController(IContactPageService contactPageService)
        {
            _contactPageService = contactPageService;
        }

        public IActionResult Index()
        {
            var options = _contactPageService.GetContactPage();
            return PartialView(options);
        }
    }
}
