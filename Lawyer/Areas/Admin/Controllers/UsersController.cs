using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using Lawyer.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Lawyer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class UsersController : Controller
    {
        private readonly IUserAdditioanlPropertiesService _userAdditioanalPropertiesService;
        private readonly IUserService _userService;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IOperationClaimService _operationClaimService;
        private IAuthService _authService;


        public UsersController(IUserAdditioanlPropertiesService userAdditioanalPropertiesService, IUserService userService, IUserOperationClaimService userOperationClaimService, IOperationClaimService operationClaimService, IAuthService authService)
        {
            _userAdditioanalPropertiesService = userAdditioanalPropertiesService;
            _userService = userService;
            _userOperationClaimService = userOperationClaimService;
            _operationClaimService = operationClaimService;
            _authService = authService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userAdditioanalPropertiesService.GetByIdDtoForAdminPanel(Convert.ToInt32(userId)).Data;


            return View(user);
        }
        [HttpGet]
        public IActionResult UpdateUserRoles(int id)
        {
            var userAddProp=_userAdditioanalPropertiesService.GetByIdDtoForAdminPanel(id).Data;
            var user = _userService.Get(id);
            
            ViewBag.Roles = _operationClaimService.GetAll().Data;
            
            var userRoles = _userOperationClaimService.GetByUserId(id).Data;
            var tuple= new Tuple<UserForTeamDTO,List<UserOperationClaim>>(userAddProp, userRoles);

            return View(tuple);
        } [HttpPost]
        public IActionResult UpdateUserRoles(List<int> selectedRoles, int userId)
        {
            _userOperationClaimService.RemoveAllClaimsByUserId(userId);
            foreach (var item in selectedRoles)
            {
                _userOperationClaimService.AddClaim(userId, item);
            }
            var routeValues = new RouteValueDictionary { { "id", userId } };

            return RedirectToAction("UpdateUserRoles", "Users", routeValues);
        }

        [HttpGet]
        public IActionResult Users()
        {
           
            return View(_userAdditioanalPropertiesService.GetAllDetails().Data);
        }
        [HttpGet]
        public IActionResult UpdateUserTeamMember()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateUserTeamMember(UserForTeamDTO userForTeam)
        {
            var value=_userAdditioanalPropertiesService.GetByUserId(userForTeam.UserId).Data;
            value.TeamStatus = userForTeam.TeamStatus;
            _userAdditioanalPropertiesService.Update(value);
            var routeValues = new RouteValueDictionary { { "id", userForTeam.UserId } };

            return RedirectToAction("UpdateUserRoles", "Users", routeValues);
        }
      
        public IActionResult UserDelete(int id)
        {
            var value=_userService.Get(id).Data;
            value.Status = false;
            var result =_userService.Update(value);
            if (result.Success)
            {
                return RedirectToAction("Users", "Users");
            }
            return BadRequest("Silme işlemi başarısız oldu");
        }
        
        public IActionResult UpdateUser(UserForTeamDTO user)
        {
          //  user.TeamStatus = _userAdditioanalPropertiesService.GetByIdDtoForAdmniPanel(user.UserAdditionaPropertylId).Data.TeamStatus;
            var updatingUser=_userService.Get(user.UserId).Data;
            var updatingUserAdditionalProp=_userAdditioanalPropertiesService.GetByUserId(user.UserId).Data;

            updatingUser.FirstName = user.FirstName;
            updatingUser.LastName = user.LastName;
            updatingUser.Email = user.Mail;

            updatingUserAdditionalProp.PhoneNumber = user.PhoneNumber;
            updatingUserAdditionalProp.Facebook = user.Facebook;
            updatingUserAdditionalProp.Twitter = user.Twitter;
            updatingUserAdditionalProp.Profession = user.Profession;
            updatingUserAdditionalProp.About = user.AboutUser;
            updatingUserAdditionalProp.Instagram = user.Instagram;
            updatingUserAdditionalProp.Linkedln = user.Linkedln;

           var usProp= _userAdditioanalPropertiesService.Update(updatingUserAdditionalProp);
           var us= _userService.Update(updatingUser);

            if (usProp.Success && us.Success)
            {
                return RedirectToAction("Index", "Users");
            }
            return BadRequest("Güncelleme işlemi Sırasında Bir Hata Oluştu");
        }

        public ActionResult ChangePassword(ChangePasswordDTO changePassword)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userService.Get(Convert.ToInt32(userId)).Data;
            changePassword.Email = user.Email;

            var passCheck= ConfirmPassword(changePassword.NewPassword, changePassword.NewPasswordReply);
            if (!passCheck)
            {
                TempData["Pass"] = "Sifreler Ayni Degil";
                return RedirectToAction("Index", "Users");
            }
            
           var value= _authService.ChangePassword(changePassword);
            TempData["Response"] = value.Message;
            return RedirectToAction("Index", "Users");
        }
        private bool ConfirmPassword(string pass1,string pass2)
        {
            if (pass1==pass2)
            {
                return true;
            }
            return false;
        }
    }
}
