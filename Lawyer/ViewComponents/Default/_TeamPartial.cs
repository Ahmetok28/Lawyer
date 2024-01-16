using Business.Abstract;
using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _TeamPartial : ViewComponent
    {
        IUserAdditioanlPropertiesService _teamService;

        public _TeamPartial(IUserAdditioanlPropertiesService teamService)
        {
            _teamService = teamService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _teamService.GetAllIfTeamMemberExistsDto().Data;
            return View(values);
        }
    } }
