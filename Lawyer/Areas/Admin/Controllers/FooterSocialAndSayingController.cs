using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize]
    public class FooterSocialAndSayingController : Controller
    {
        private readonly IFooterSocialAndSayingService _socialMediaService;

        public FooterSocialAndSayingController(IFooterSocialAndSayingService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_socialMediaService.Get().Data);
        }
        [HttpPost]
        public IActionResult Index(FooterSocialAndSaying officeSocial)
        {
            _socialMediaService.Update(officeSocial);
            return RedirectToAction("Admin");
        }
    }
}
