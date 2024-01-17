using Business.Abstract;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Security.Claims;

namespace Lawyer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                ViewBag.UserNo = "Kullanıcı Adı Veya Şifre Hatalı!";
                return View();
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                SaveToken(result.Data);
                //return RedirectToRoute("Admin");
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            return BadRequest(result);

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            
            if (registerResult.Success)
            {

                return RedirectToAction("Users","Users" );
            }

            return BadRequest(registerResult.Message);
        }

        public async Task<IActionResult> Logout() 
        {
            RemoveToken();

            return RedirectToAction("Index","Default");

        }

        private void RemoveToken ()
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddYears(-1)
            };

            Response.Cookies.Append("AccessToken", "", cookieOptions);
        }
      
     
        private void SaveToken(AccessToken token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = token.Expiration
            };
            
            Response.Cookies.Append("AccessToken", token.Token, cookieOptions);
        }

    }
}
