using Business.Abstract;
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
    }
}
