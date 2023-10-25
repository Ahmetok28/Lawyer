using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
    public class PracticeAreaController : Controller
    {
        PracticeAreaManager practiceAreaManager = new PracticeAreaManager(new EfPracticeAreaDal());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PracticeAreas(int id)
        {
           var value= practiceAreaManager.GetById(id);
            return View(value);
        } 
       
    

        [HttpPost]
        public IActionResult PracticeAreas(PracticeArea p)
        {
           
            return View();
        }

   
    }
}
