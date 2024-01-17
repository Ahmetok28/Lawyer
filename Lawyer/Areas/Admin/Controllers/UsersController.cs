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


        public UsersController(IUserAdditioanlPropertiesService userAdditioanalPropertiesService, IUserService userService, IUserOperationClaimService userOperationClaimService, IOperationClaimService operationClaimService)
        {
            _userAdditioanalPropertiesService = userAdditioanalPropertiesService;
            _userService = userService;
            _userOperationClaimService = userOperationClaimService;
            _operationClaimService = operationClaimService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userAdditioanalPropertiesService.GetByIdDto(Convert.ToInt32(userId)).Data;


            return View(user);
        }
        [HttpGet]
        public IActionResult UpdateUserRoles(int id)
        {
            var user=_userAdditioanalPropertiesService.GetByIdDto(id).Data;
            ViewBag.Roles = _operationClaimService.GetAll().Data;
            

            return View(user);
        } [HttpPost]
        public IActionResult UpdateUserRoles(UserOperationClaim userOperationClaim)
        {

            return View();
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
    //    [HttpPost]
    //    public IActionResult DeleteUser(User user)
    //    {
            

    //        return RedirectToAction("UpdateUserRoles", "Users");
    //    }
    }
}
