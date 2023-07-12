using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHomeTextService
    {
        void Add(HomeText homeText);
        void Update(HomeText homeText);
        void Delete(HomeText homeText);
        HomeText GetHomeText();
    }
}
