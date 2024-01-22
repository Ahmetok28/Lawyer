using Business.Abstract;
using Entities.Concrete;
using Lawyer.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lawyer.Areas.Admin.ViewComponents.Default
{
    public class _AdminNavbarComponent:ViewComponent
    {
        private readonly IUserAdditioanlPropertiesService _userAdditioanlProperties;

        public _AdminNavbarComponent(IUserAdditioanlPropertiesService userAdditioanlProperties)
        {
            _userAdditioanlProperties = userAdditioanlProperties;
        }

      
        public IViewComponentResult Invoke()
        {
            var userId = (User as ClaimsPrincipal)?.FindFirstValue(ClaimTypes.NameIdentifier);
            var userRole = (User as ClaimsPrincipal)?.IsInRole("Admin");
            ViewBag.Admin = userRole;
            var values = _userAdditioanlProperties.GetByIdDtoForAdminPanel(Convert.ToInt32(userId)).Data;
            if (values.Profession==null)
            {
                values.Profession = "";
            }
            var navbarView = new NavbarViewModel
            {
                Name = values.FullName,
                Photo = values.ProfliePhoto,
                Profession = values.Profession
            };

            return View(navbarView);
        }
    }
}
