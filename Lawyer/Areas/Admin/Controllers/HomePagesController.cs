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
    }
}
