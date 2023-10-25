using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Sections
{
    public class _SectionList : ViewComponent
    {
        SectionManager sectionManager = new SectionManager(new EfSectionDal());
        public IViewComponentResult Invoke(int id)
        {
            var value =sectionManager.GetSectionByPracticeAreaId(id);
            return View(value);
        }
    }
}