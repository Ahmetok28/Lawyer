using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ContactPage:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string PageText { get; set; }
        public string OfficeAdress { get; set; }
        public string OfficeTelephone { get; set; }
        public string OfficeMail { get; set; }
        public string? MapAdress { get; set; }
    }
}
