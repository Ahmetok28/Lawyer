using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
    public class AboutController : Controller
    {
       
        public IActionResult Index()
        {
           return View();
        }
    }
}
