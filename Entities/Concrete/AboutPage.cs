using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AboutPage:IEntity
    {
        public int Id { get; set; }
        public string WhoWeAreTitle { get; set; }
        public string WhoWeAreContent { get; set; }
        public string TeamText { get; set; }
       


    }
}
