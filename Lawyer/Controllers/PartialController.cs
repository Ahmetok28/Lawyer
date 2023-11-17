using Business.Abstract;
using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
    public class PartialController : Controller
    {
        IPracticeAreaService _practiceAreaService;

        public PartialController(IPracticeAreaService practiceAreaService)
        {
            _practiceAreaService = practiceAreaService;
        }

        
        public PartialViewResult NavbarPartial()
        {
            var value = _practiceAreaService.GetTitleAndId();
            return PartialView(value);
        }
    }
}
