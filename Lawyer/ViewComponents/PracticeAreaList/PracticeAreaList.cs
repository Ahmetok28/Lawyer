using Business.Abstract;
using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.PracticeAreaList
{
    public class PracticeAreaList:ViewComponent
    {
        IPracticeAreaService _practiceAreaService;

        public PracticeAreaList(IPracticeAreaService practiceAreaService)
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
