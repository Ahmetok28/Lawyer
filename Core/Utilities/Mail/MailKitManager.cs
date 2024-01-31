using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Mail
{
    public class MailKitManager : IMailService
    {
        public Task SendEmail(MailMessage mail, EmailConfiguration mailConfig)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress(mailConfig.Sender, mailConfig.SenderEmail);
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mail.ToMailAddres);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mail.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mail.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect(mailConfig.SmtpServer, mailConfig.SmtpPort, false);
            client.Authenticate(mailConfig.SenderEmail, mailConfig.SenderPassword);
            client.Send(mimeMessage);
            client.Disconnect(true);
            return Task.CompletedTask;
        }
    }
}
