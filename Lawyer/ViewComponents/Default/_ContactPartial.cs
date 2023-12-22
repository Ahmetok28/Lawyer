using Business.Abstract;
using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _ContactPartial : ViewComponent
    {
        IContactService _contactService;
        IPracticeAreaService _practiceAreaService;

        public _ContactPartial(IContactService contactService, IPracticeAreaService practiceAreaService)
        {
            _contactService = contactService;
            _practiceAreaService = practiceAreaService;
        }

      
        public IViewComponentResult Invoke()
        {
            var value = _contactService.GetContact().Data;
            var value2 = _practiceAreaService.GetAll().Data;
            var model = Tuple.Create(value, value2);
            return View(model);
        }

       
    } 
}
