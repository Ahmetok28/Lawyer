using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _CallPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    } }
