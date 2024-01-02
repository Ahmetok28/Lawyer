using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class WhyChooseUsDTO:IDto
    {
        public int WCUId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LogoName { get; set; }
        public string LogoText { get; set; }
        public int LogoId { get; set; }
    }
}
