using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using Entities.DTOs;
using Business.Abstract;

namespace Lawyer.Filters
{
    public class PracticeAreaFilter : IActionFilter
    {
        IPracticeAreaService _practiceAreaService;

        public PracticeAreaFilter(IPracticeAreaService practiceAreaService)
        {
            _practiceAreaService = practiceAreaService;
        }

       
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var model = _practiceAreaService.GetTitleAndId(); // Model verisi
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
