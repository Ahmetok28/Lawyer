using Business.Abstract;
using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
    public class AboutController : Controller
    {
        ITeamService _teamService;

        public AboutController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
           return View();
        }
        public IActionResult AboutMe(int id)
        {
          var value=  _teamService.GetByTeamId(id);
           return View(value);
        }
    }
}
