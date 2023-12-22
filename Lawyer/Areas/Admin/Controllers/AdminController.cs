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
        
    }
}
