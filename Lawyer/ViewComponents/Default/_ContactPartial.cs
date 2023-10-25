using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _ContactPartial : ViewComponent
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        PracticeAreaManager practiceAreaManager= new PracticeAreaManager(new EfPracticeAreaDal());
        public IViewComponentResult Invoke()
        {
            var value = contactManager.GetContact();
            var value2 = practiceAreaManager.GetAll();
            var model = Tuple.Create(value, value2);
            return View(model);
        }

       
    } 
}
