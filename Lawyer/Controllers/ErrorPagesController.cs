using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
    
    public class ErrorPagesController : Controller
    {
        [Route("ErrorPages/PageNotFound")]
        public IActionResult PageNotFound(int statusCode)
        {
            if (statusCode==401)
            {
                return RedirectToAction("Login", "Auth", new { area = "Admin" });
            }
            return View();
         

        } 
        public IActionResult UnAuthorize(int code)
        {


            return RedirectToAction("Login", "Auth", new { area = "Admin" });


        }
        public IActionResult AuthorNotFound()
        {


            return View();


        } 
       
    }
}
