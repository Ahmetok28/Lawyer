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
            var options = _practiceAreaService.GetAll().Data;
            return PartialView(options);
        } 
        [HttpPost]
        public IActionResult AddMessage(Message message)
        {
            message.SendTime= Convert.ToDateTime(DateTime.Now);
            message.Status = false;
            message.IsImportant= false;

            var result=_messageService.Add(message);
            if (result.Success)
            {
                return Ok(result.Message.ToString());
            }
            return BadRequest(result.Message.ToString());
           
        }
    }
}
