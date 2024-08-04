using Entities.Concrete;
using Lawyer.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lawyer.Areas.Admin.ViewComponents.Default
{
    public class _AdminSideBarComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.Admin = (User as ClaimsPrincipal)?.IsInRole("Admin");
            ViewBag.Editor = (User as ClaimsPrincipal)?.IsInRole("Editor");
            ViewBag.Yazar = (User as ClaimsPrincipal)?.IsInRole("Yazar");
            ViewBag.User = (User as ClaimsPrincipal)?.IsInRole("User");

            //var claimModel = new ClaimModel
            //{
            //    Admin = (bool)admin,
            //    Editor = (bool)editor,
            //    Yazar = (bool)yazar,
            //    User = (bool)user
            //};
            //ViewBag.v1= claimModel;
            return View();
        }
    }
}
