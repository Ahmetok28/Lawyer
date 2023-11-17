using Business.Abstract;
using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Sections
{
    public class _SectionList : ViewComponent
    {
        ISectionService _sectionService;

        public _SectionList(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var value = _sectionService.GetSectionByPracticeAreaId(id);
            return View(value);
        }
    }
}