using Business.Abstract;
using Core.Utilities.Mail;
using Entities.Concrete;
using Lawyer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lawyer.Controllers
{
    public class MailController : Controller
    {
        private readonly IEmailConfigurationService _emailConfigurationService;
        private readonly IMailService _mailService;
        private readonly ISuscriberService _suscriberService;

        public MailController(IEmailConfigurationService emailConfigurationService, IMailService mailService, ISuscriberService suscriberService)
        {
            _emailConfigurationService = emailConfigurationService;
            _mailService = mailService;
            _suscriberService = suscriberService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SuscribeNewsletter(Subscriber subscriber)
        {

            _suscriberService.Add(subscriber);
            var mailContent = new MailMessage
            {
                Body = "Aramıza Hoş Geldiniz,\r\n\r\n" +
                "Bu kısa not, Av. Ertuğrul Yapar'ın web sitesine bültenimize abone olduğunuz için size iletilmiştir. Sizlere en güncel hukuki gelişmeler, önemli bilgiler ve özel etkinlikler hakkında bilgi sağlamaktan heyecan duyuyoruz." +
                "\r\n\r\nBizimle birlikte olduğunuz için minnettarız ve sizinle paylaşacak daha pek çok bilgi olduğuna eminiz. Bizimle iletişimde kalın ve sizlere en iyi hukuki hizmeti sunmak için burada olduğumuzu unutmayın." +
                "\r\n\r\nEğer herhangi bir konuda sorularınız veya geri bildirimleriniz olursa, lütfen çekinmeden bizimle iletişime geçin. Sizden haber almak bizi memnun eder." +
                "\r\n\r\nİyi günler dileriz!" +
                "\r\n\r\nSaygılarımla," +
                "\r\nAv. Ertuğrul Yapar" +
                "\r\n",
                Subject = "Bültene Kayıt Olduğunuz için Teşekkürler.",
                ToMailAddres = subscriber.EMail
            };

            _mailService.SendEmail(mailContent, _emailConfigurationService.Get().Data);
            return RedirectToAction("Index","Blog");
        }
    }
}
