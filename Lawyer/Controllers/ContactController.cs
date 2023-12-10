using Business.Abstract;
using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Lawyer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
    public class ContactController : Controller
    {
        IContactPageService _contactPageService;
        IContactService _contactService;
        IPracticeAreaService _practiceAreaService;

        public ContactController(IContactPageService contactPageService, IContactService contactService, IPracticeAreaService practiceAreaService)
        {
            _contactPageService = contactPageService;
            _contactService = contactService;
            _practiceAreaService = practiceAreaService;
        }

      
        public IActionResult Index()
        {
            var contactData = _contactService.GetContact();
            var practiceAreas = _practiceAreaService.GetAll();
            var contactPageData = _contactPageService.GetContactPage();

            
            var viewModel = new ContactPageViewModel
            {
                ContactData = contactData,
                PracticeAreas = practiceAreas,
                ContactPageData = contactPageData
            };

            
            return PartialView(viewModel);
        }
    }
}
