using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _OffersPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    } }
