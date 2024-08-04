using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin,Editor")]
    public class IncomingMessagesController : Controller
    {
        private readonly IMessageService messageService;

        public IncomingMessagesController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public IActionResult Index()
        {
           
            return View(messageService.GetAll().Data);
        }
        [HttpGet]
        public IActionResult MessageDateail(int id)
        {
            var message = messageService.GetMessage(id).Data;
            message.Status = true;
            messageService.Update(message);
            return View(message);
        }

    }
}
