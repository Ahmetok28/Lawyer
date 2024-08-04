using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _FeaturePartial:ViewComponent
    {
        private readonly IHomeButtonsService _homeButtonsService;

        public _FeaturePartial(IHomeButtonsService homeButtonsService)
        {
            _homeButtonsService = homeButtonsService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_homeButtonsService.Get().Data);
        }
    } 
}
