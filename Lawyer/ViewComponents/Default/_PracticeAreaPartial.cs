using Business.Abstract;
using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _PracticeAreaPartial : ViewComponent
    {
        IPracticeAreaService _practiceAreaService;
        public _PracticeAreaPartial(IPracticeAreaService practiceAreaService)
        {
            _practiceAreaService = practiceAreaService;
        }


        public IViewComponentResult Invoke()
        {
            var values = _practiceAreaService.GetAll();

            return View(values);
        }
    }
}
