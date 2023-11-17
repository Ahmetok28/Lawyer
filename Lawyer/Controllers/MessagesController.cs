using Business.Abstract;
using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
    public class MessageController : Controller
    {
        IMessageService _messageService;
        IPracticeAreaService _practiceAreaService;

        public MessageController(IPracticeAreaService practiceAreaService, IMessageService messageService)
        {
            _practiceAreaService = practiceAreaService;
            _messageService = messageService;
        }

       

  

        [HttpGet]
        public IActionResult AddMessage()    
        {
            var options = _practiceAreaService.GetAll();
            return PartialView(options);
        } 
        [HttpPost]
        public IActionResult AddMessage(Message message)
        {
            message.SendTime= Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.Status = false;
            message.IsImportant= false;
            _messageService.Add(message);
            return RedirectToAction("Index", "Default");
        }
    }
}
