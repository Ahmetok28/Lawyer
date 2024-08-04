using Business.Abstract;
using Lawyer.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _HeadPartial:ViewComponent
    {
        IWebMetaSettingService _webMetaSetting;

        public _HeadPartial(IWebMetaSettingService webMetaSetting)
        {
            _webMetaSetting = webMetaSetting;
        }

        public IViewComponentResult Invoke()
        {
            
            return View(_webMetaSetting.Get().Data);
        }
    }
}
