using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutTextService
    {
        void Add(AboutText aboutText);
        void Update(AboutText aboutText);
        void Delete(AboutText aboutText);
        AboutText GetAboutText();
    }
}
