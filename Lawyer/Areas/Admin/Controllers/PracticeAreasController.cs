using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Route("Admin/[controller]/[action]/{id?}")]
    public class PracticeAreasController : Controller
    {
        private readonly IPracticeAreaService _practiceAreaService;

        public PracticeAreasController(IPracticeAreaService practiceAreaService)
        {
            _practiceAreaService = practiceAreaService;
        }

        public IActionResult Index()
        {
           
            return View(_practiceAreaService.GetAll().Data);
        }
        #region Çalışma Alanı Ekleme
        [HttpGet]
        public IActionResult Add(int id)
        {
            
            return View(_practiceAreaService.GetById(id).Data);
        } 
        [HttpPost]
        public IActionResult Add(PracticeArea practiceArea)
        {
            _practiceAreaService.Add(practiceArea);
            return RedirectToAction("Index");
        }

        #endregion

        #region Çalışma Alanı Güncelleme
        [HttpGet]
        public IActionResult Update(int id)
        {

            return View(_practiceAreaService.GetById(id).Data);
        }
        [HttpPost]
        public IActionResult Update(PracticeArea practiceArea)
        {
            _practiceAreaService.Update(practiceArea);
            return RedirectToAction("Index");
        }

        #endregion

        #region Çalışma Alanı Silme
        [HttpGet]
        public IActionResult Delete(int id)
        {

            return View(_practiceAreaService.GetById(id).Data);
        }
        [HttpPost]
        public IActionResult Delete(PracticeArea practiceArea)
        {
            _practiceAreaService.Delete(practiceArea);
            return RedirectToAction("Index");
        }

        #endregion

        #region Çalışma Alanı Detayı
        [HttpGet]
        public IActionResult Details(int id)
        {

            return View(_practiceAreaService.GetById(id).Data);
        }
       

        #endregion
    }
}
