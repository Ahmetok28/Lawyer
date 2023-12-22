using Business.Abstract;
using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _TeamPartial : ViewComponent
    {
        ITeamService _teamService;

        public _TeamPartial(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _teamService.GetAll().Data;
            return View(values);
        }
    } }
