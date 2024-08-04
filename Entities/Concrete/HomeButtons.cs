using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class HomeButtons:IEntity
    {
        public int Id { get; set; }
        public string? Button1 { get; set; }
        public string? Button2 { get; set; }
        public string? Button3 { get; set; }
        public string? Button1Link { get; set; }
        public string ?Button2Link { get; set; }
        public string ?Button3Link { get; set; }
    }
}
