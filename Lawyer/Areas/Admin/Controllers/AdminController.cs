using Business.Abstract;
using DataAccess.Conrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace Lawyer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize]

    public class AdminController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IBlogService _blogService;
        private readonly IPracticeAreaService _practiceArea;

        public AdminController(IMessageService messageService, IBlogService blogService, IPracticeAreaService practiceArea)
        {
            _messageService = messageService;
            _blogService = blogService;
            _practiceArea = practiceArea;
        }

        public IActionResult Index(string filter)
        {


            ViewBag.Msg = _messageService.GetAll().Data.Count;
            ViewBag.Blogs =_blogService.GetAll().Data.Count;
            ViewBag.Areas =_practiceArea.GetAll().Data.Count;
            ViewBag.Messages =GetFilteredMessages(filter);
            if (User.IsInRole("Admin")|| User.IsInRole("Editor")|| User.IsInRole("Yazar"))
            {
                // Kullanıcı "Admin" rolüne sahipse, admin sayfasını göster
                return View();
            }
            
            else
            {
                // Kullanıcı "Admin" rolüne sahip değilse, başka bir sayfaya yönlendir
                
                return RedirectToAction("Index", "Users"); // Örneğin, erişim reddedildi sayfasına yönlendirilebilir.
            }
        }

        private List<Message> GetFilteredMessages(string filter)
        {
            // Tarih filtresine göre mesajları getirme işlemleri
           
            DateTime startDate, endDate;
            if (filter == "Today")
            {
                startDate = DateTime.Today;
                endDate = DateTime.Today.AddDays(1).AddTicks(-1);
            }
            else if (filter == "All")
            {
                return _messageService.GetAll().Data;
            }
            else if (filter == "ThisMonth")
            {
                startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                endDate = startDate.AddMonths(1).AddTicks(-1);
            }
            else if (filter == "ThisYear")
            {
                startDate = new DateTime(DateTime.Now.Year, 1, 1);
                endDate = startDate.AddYears(1).AddTicks(-1);
            }
            else
            {
                // Varsayılan olarak tüm mesajları getir
                startDate = DateTime.MinValue;
                endDate = DateTime.MaxValue;
            }

            // Mesajları seçilen tarih aralığına göre filtreleme
            var filteredMessages = _messageService.GetAll().Data.Where(m => m.SendTime >= startDate && m.SendTime <= endDate).ToList();

            return filteredMessages;
        }

    }
}
