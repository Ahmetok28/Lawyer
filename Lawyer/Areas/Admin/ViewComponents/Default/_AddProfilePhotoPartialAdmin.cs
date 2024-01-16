using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lawyer.Areas.Admin.ViewComponents.Default
{
    public class _AddProfilePhotoPartialAdmin : ViewComponent
    {
        private readonly IProfilePhotoService _profilePhotoService;

        public _AddProfilePhotoPartialAdmin(IProfilePhotoService profilePhotoService)
        {
            _profilePhotoService = profilePhotoService;
        }

      

       
        public IViewComponentResult Invoke()
        {
            

            return View();
        }
    }
}
