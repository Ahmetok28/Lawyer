using Business.Abstract;
using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Lawyer.Controllers
{
    public class AboutController : Controller
    {
        private readonly IUserAdditioanlPropertiesService _teamService;
        private readonly IAboutPageService _aboutPageService;
        private readonly IWhyChooseUsService _whyChooseUsService;
        private readonly IWhatsSaidAboutUsService _whatsSaidAboutUsService;


        public AboutController(IUserAdditioanlPropertiesService teamService, IAboutPageService aboutPageService, IWhyChooseUsService whyChooseUsService, IWhatsSaidAboutUsService whatsSaidAboutUsService)
        {
            _teamService = teamService;
            _aboutPageService = aboutPageService;
            _whyChooseUsService = whyChooseUsService;
            _whatsSaidAboutUsService = whatsSaidAboutUsService;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = _aboutPageService.GetAboutPage().Data;
            ViewBag.v2 = _whatsSaidAboutUsService.GetAll().Data;
            ViewBag.v3 = _whyChooseUsService.GetAllWithLogos().Data;
           return View();
        }
        public IActionResult AboutMe(int id)
        {
            var value=  _teamService.GetByIdDto(id);

            if (value.Data == null)
            {
                return RedirectToAction("AuthorNotFound", "ErrorPages");
            }
            return View(value.Data);
        }
    }
}
