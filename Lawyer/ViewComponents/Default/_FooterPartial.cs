﻿using Business.Abstract;
using DataAccess.Migrations;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _FooterPartial : ViewComponent
    {
        private readonly IPracticeAreaService _practiceAreaService;
        private readonly IContactPageService _contactPageService;
        private readonly IFooterSocialAndSayingService _officeSocialService;
        public _FooterPartial(IPracticeAreaService practiceAreaService, IContactPageService contactPageService, IFooterSocialAndSayingService officeSocialService)
        {
            _practiceAreaService = practiceAreaService;
            _contactPageService = contactPageService;
            _officeSocialService = officeSocialService;
        }


        public IViewComponentResult Invoke()
        {
            ViewBag.Social = _officeSocialService.Get().Data;
            var practiceAreas = _practiceAreaService.GetAll().Data;
            var contact = _contactPageService.GetContactPage().Data;
            return View(Tuple.Create(practiceAreas, contact) );
        }
    }
}
