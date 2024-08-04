using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lawyer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles ="Admin")]
    public class AboutPageController : Controller
    {
        private readonly IAboutPageService _aboutPageService;
        private readonly IWhyChooseUsService _whyChooseUsService;
        private readonly IWhatsSaidAboutUsService _whatsSaidAboutUsService;
        private readonly IWhyChooseLogoService _whyChooseLogoService;

        public AboutPageController(IWhyChooseUsService whyChooseUsService, IAboutPageService aboutPageService, IWhatsSaidAboutUsService whatsSaidAboutUsService, IWhyChooseLogoService whyChooseLogoService)
        {
            _whyChooseUsService = whyChooseUsService;
            _aboutPageService = aboutPageService;
            _whatsSaidAboutUsService = whatsSaidAboutUsService;
            _whyChooseLogoService = whyChooseLogoService;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = _aboutPageService.GetAboutPage().Data;
            ViewBag.v2 = _whatsSaidAboutUsService.GetAll().Data;
            ViewBag.v3 = _whyChooseUsService.GetAllWithLogos().Data;
            return View();
        }
        #region Hakkımızda Sayfası Giriş Güncelleme
        [HttpGet]
        public IActionResult UpdateAboutPage(int id)
        {
            return View(_aboutPageService.GetAboutPage().Data);
        }
        [HttpPost]
        public IActionResult UpdateAboutPage(AboutPage aboutPage)
        {
            _aboutPageService.Update(aboutPage);
            return RedirectToAction("Index");
        }
        #endregion

        #region Neden Bizi Seçmelisiniz Kısımı Madde Ekleme
        [HttpGet]
        public IActionResult AddWhyChoose()
        {
            ViewBag.Logos = _whyChooseLogoService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult AddWhyChoose(WhyChooseUs whyChooseUs)
        {
            _whyChooseUsService.Add(whyChooseUs);
            return RedirectToAction("Index");
        }
        #endregion

        #region Neden Bizi Seçmelisiniz Kısımı Madde Güncelleme
        [HttpGet]
        public IActionResult UpdateWhyChooseUs(int id)
        {
            ViewBag.logos = _whyChooseLogoService.GetAll().Data;
            
            return View(_whyChooseUsService.GetWhyChooseUsById(id).Data);
        }
         [HttpPost]
        public IActionResult UpdateWhyChooseUs(WhyChooseUs whyChooseUs)
        {
            _whyChooseUsService.Update(whyChooseUs);
            return RedirectToAction("Index");
        }
        #endregion

        #region Neden Bizi Seçmelisiniz Kısımı Silme
        [HttpGet]
        public IActionResult DeleteWhyChooseUs(int id)
        {
            return View(_whyChooseUsService.GetWhyChooseUsById(id).Data);
        }
         [HttpPost]
        public IActionResult DeleteWhyChooseUs(WhyChooseUs whyChooseUs)
        {
            _whyChooseUsService.Delete(whyChooseUs);
            return RedirectToAction("Index");
        }
        #endregion

        #region Hakkımızda Söylenenler Ekleme
        [HttpGet]
        public IActionResult AddWhatSaids()
        {
            ;
            return View();
        }

        [HttpPost]
        public IActionResult AddWhatSaids(WhatsSaidAboutUs whatsSaidAboutUs)
        {
            _whatsSaidAboutUsService.Add(whatsSaidAboutUs);
            return RedirectToAction("Index");
        }
        #endregion

        #region Hakkımızda Söylenenler Güncelleme
        [HttpGet]
        public IActionResult UpdateWhatSaids(int id)
        {
            
            return View(_whatsSaidAboutUsService.GetWhatsSaidAboutUsById(id).Data);
        }

        [HttpPost]
        public IActionResult UpdateWhatSaids(WhatsSaidAboutUs whatsSaidAboutUs)
        {
            _whatsSaidAboutUsService.Update(whatsSaidAboutUs);
            return RedirectToAction("Index");
        }
        #endregion

        #region Hakkımızda Söylenenler Silme
        [HttpGet]
        public IActionResult DeleteWhatsSaids(int id)
        {
            return View(_whatsSaidAboutUsService.GetWhatsSaidAboutUsById(id));
        }

        [HttpPost]
        public IActionResult DeleteWhatsSaids(WhatsSaidAboutUs whatsSaidAboutUs)
        {
            _whatsSaidAboutUsService.Delete(whatsSaidAboutUs);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
