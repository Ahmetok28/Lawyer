using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Mail
{
    public class MailMessage 
    {
      
        public string ToMailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
