using Business.Concrete;
using DataAccess.Conrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        PracticeAreaManager practiceAreaManager =new PracticeAreaManager(new EfPracticeAreaDal());

  

        [HttpGet]
        public IActionResult AddMessage()    
        {
            var options = practiceAreaManager.GetAll();
            return PartialView(options);
        } 
        [HttpPost]
        public IActionResult AddMessage(Message message)
        {
            message.SendTime= Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.Status = false;
            message.IsImportant= false;
            messageManager.Add(message);
            return RedirectToAction("Index", "Default");
        }
    }
}
