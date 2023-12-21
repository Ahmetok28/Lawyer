using Business.Abstract;
using DataAccess.Conrete.EntityFramework;
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
            
            if (User.IsInRole("Admin"))
            {
                // Kullanıcı "Admin" rolüne sahipse, admin sayfasını göster
                return View();
            }
            else
            {
                // Kullanıcı "Admin" rolüne sahip değilse, başka bir sayfaya yönlendir
                
                return RedirectToAction("AccessDenied", "Account"); // Örneğin, erişim reddedildi sayfasına yönlendirilebilir.
            }
        }
        public IActionResult BlogDetails()
        {
            var values = _practiceAreaService.GetAll();

            return View(values);
        }
    }
}
