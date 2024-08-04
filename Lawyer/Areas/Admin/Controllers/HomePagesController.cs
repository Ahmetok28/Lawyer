using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize]

    public class HomePagesController : Controller
    {
        private readonly IHomeTextService _homeTextService;
        private readonly IAboutTextService _aboutTextService;
        private readonly IHomeButtonsService _homeButtonsService;

        public HomePagesController(IHomeTextService homeTextService, IAboutTextService aboutTextService, IHomeButtonsService homeButtonsService)
        {
            _homeTextService = homeTextService;
            _aboutTextService = aboutTextService;
            _homeButtonsService = homeButtonsService;
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
        public IActionResult EditHeader([FromForm] IFormFile file,HomeText homeText) 
        {
           
            _homeTextService.Update(file,homeText);
            return RedirectToAction("Index");
        }  
        [HttpGet]
        public IActionResult EditAbout() 
        {           
            return View(_aboutTextService.GetAboutText().Data);
        }
        [HttpPost]
        public IActionResult EditAbout(IFormFile file, AboutText aboutText) 
        {
            _aboutTextService.Update(file,aboutText);
            return RedirectToAction("Index");
        }  
         [HttpGet]
        public IActionResult EditButtons() 
        {           
            return View(_homeButtonsService.Get().Data);
        }
        [HttpPost]
        public IActionResult EditButtons(HomeButtons homeButtons) 
        {
            _homeButtonsService.Update(homeButtons);
            return RedirectToAction("Index");
        }  
        
        
    }
}
