using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _SponsorsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    } }
