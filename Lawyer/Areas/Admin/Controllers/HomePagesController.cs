using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]

    public class HomePagesController : Controller
    {
        private readonly IHomeTextService _homeTextService;
        private readonly IAboutTextService _aboutTextService;

        public HomePagesController(IHomeTextService homeTextService, IAboutTextService aboutTextService)
        {
            _homeTextService = homeTextService;
            _aboutTextService = aboutTextService;
        }

        public IActionResult Index()
        {
           
            return View(_homeTextService.GetHomeText().Data);
        }
        [HttpGet]
        public IActionResult EditHeader() 
        {           
            return View(_homeTextService.GetHomeText().Data);
        }
        [HttpPost]
        public IActionResult EditHeader(HomeText homeText) 
        {     
            _homeTextService.Update(homeText);
            return RedirectToAction("Index");
        }  
        [HttpGet]
        public IActionResult EditAbout() 
        {           
            return View(_aboutTextService.GetAboutText().Data);
        }
        [HttpPost]
        public IActionResult EditAbout(AboutText aboutText) 
        {
            _aboutTextService.Update(aboutText);
            return RedirectToAction("Index");
        }    
    }
}
