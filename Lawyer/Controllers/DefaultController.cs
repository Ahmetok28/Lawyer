﻿using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
    public class DefaultController : Controller
    {
        
        public IActionResult Index()
        {
          return View();
        }
        
    }
}
