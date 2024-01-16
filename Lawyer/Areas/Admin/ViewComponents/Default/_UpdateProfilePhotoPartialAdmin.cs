using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lawyer.Areas.Admin.ViewComponents.Default
{
    public class _UpdateProfilePhotoPartialAdmin : ViewComponent
    {
        private readonly IProfilePhotoService _profilePhotoService;

        public _UpdateProfilePhotoPartialAdmin(IProfilePhotoService profilePhotoService)
        {
            _profilePhotoService = profilePhotoService;
        }

      

       
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
