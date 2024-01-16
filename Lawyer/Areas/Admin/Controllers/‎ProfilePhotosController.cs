using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lawyer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class ProfilePhotosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        IProfilePhotoService _profilePhotoService;

        public ProfilePhotosController(IProfilePhotoService profilePhotoService)
        {
            _profilePhotoService = profilePhotoService;
        }
        
        [HttpPost]
        public IActionResult Add([FromForm] IFormFile file)
        {
            ProfilePhoto profilePhoto = new ProfilePhoto
            {
                UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier))
            };
            var result = _profilePhotoService.Add(file, profilePhoto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(ProfilePhoto profilePhoto)
        {
            var result = _profilePhotoService.Delete(profilePhoto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       

        [HttpPost]
        public IActionResult Update([FromForm] IFormFile file)
        {
            var photo = _profilePhotoService.GetByUserId(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier))).Data;
            var result = _profilePhotoService.Update(file, photo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _profilePhotoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _profilePhotoService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyimageid")]
        public IActionResult GetById(int imageId)
        {
            var result = _profilePhotoService.GetById(imageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
