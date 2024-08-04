using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize]
    public class ContactPageController : Controller
    {
        private readonly IContactPageService _contactPageService;
        public ContactPageController(IContactPageService contactPageService)
        {
            _contactPageService = contactPageService;
        }

        public IActionResult Index()
        {
            return View(_contactPageService.GetContactPage().Data);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_contactPageService.GetContactPageById(id).Data);
        }
        [HttpPost]
        public IActionResult Edit(ContactPage contactPage)
        {
            _contactPageService.Update(contactPage);
            return RedirectToAction("Index");
        }
    }
}
