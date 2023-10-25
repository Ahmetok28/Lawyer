using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using Entities.DTOs;

namespace Lawyer.Filters
{
    public class PracticeAreaFilter : IActionFilter
    {
        PracticeAreaManager practiceAreaManager = new PracticeAreaManager(new EfPracticeAreaDal());
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var model = practiceAreaManager.GetTitleAndId(); // Model verisi
            var controller = (Controller)context.Controller;
            controller.ViewData["Model1"] = model; // ViewData'ya ekleyin
            controller.ViewBag.Model2 = model;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Burası action çalıştırılmadan önce çalışacak kodlar için kullanılabilir (isteğe bağlı)
        }
    }
}
