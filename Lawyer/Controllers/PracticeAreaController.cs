using Business.Abstract;
using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
    public class PracticeAreaController : Controller
    {
        IPracticeAreaService _practiceAreaService;

        public PracticeAreaController(IPracticeAreaService practiceAreaService)
        {
            _practiceAreaService = practiceAreaService;
        }

       
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PracticeAreas(int id)
        {
           var value= _practiceAreaService.GetById(id).Data;
            return View(value);
        } 
       
    

        [HttpPost]
        public IActionResult PracticeAreas(PracticeArea p)
        {
           
            return View();
        }

   
    }
}
