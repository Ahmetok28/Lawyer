using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace Lawyer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    
    public class AdminController : Controller
    {
         
        IPracticeAreaService _practiceAreaService;

        public AdminController(IPracticeAreaService practiceAreaService)
        {
            _practiceAreaService = practiceAreaService;
        }

       
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult BlogDetails()
        {
            var values = _practiceAreaService.GetAll();

            return View(values);
        }
    }
}
