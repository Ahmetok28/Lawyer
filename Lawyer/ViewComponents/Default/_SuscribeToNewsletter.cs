using Microsoft.AspNetCore.Mvc;

namespace Lawyer.ViewComponents.Default
{
    public class _SuscribeToNewsletter:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
