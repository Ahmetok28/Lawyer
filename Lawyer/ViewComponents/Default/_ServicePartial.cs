using Business.Abstract;
using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _ServicePartial : ViewComponent
    {
        IPracticeAreaService _practiceAreaService;

        public _ServicePartial(IPracticeAreaService practiceAreaService)
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
