using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class FooterSocialAndSaying:IEntity
    {
        public int Id { get; set; }
        public string Saying { get; set; }
        public string? Facebook { get; set; }
        public string ?Instagram { get; set; }
        public string? Linkedin { get; set; }
        public string? Twitter { get; set; }
    }
}
