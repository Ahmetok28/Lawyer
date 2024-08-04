using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize]
    public class WebSiteSettingsController : Controller
    {
        private readonly IWebMetaSettingService _webMetaSettingService;

        public WebSiteSettingsController(IWebMetaSettingService webMetaSettingService)
        {
            _webMetaSettingService = webMetaSettingService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MetaValuesEdit()
        {
            var value = _webMetaSettingService.Get().Data;
            ViewBag.v1=value.MetaValues;
            return View(value);
        }
        [HttpPost]
        public IActionResult MetaValuesEdit(WebMetaSetting webMetaSetting)
        {
            _webMetaSettingService.Update(webMetaSetting);   
            return View();
        }
    }
}
