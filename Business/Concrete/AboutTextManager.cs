using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AboutTextManager:IAboutTextService
    {
        private readonly IAboutTextDal _aboutTextDal;

        public AboutTextManager(IAboutTextDal aboutTextDal)
        {
            _aboutTextDal = aboutTextDal;
        }

        public void Add(AboutText aboutText)
        {
            _aboutTextDal.Add(aboutText);
        }

        public void Delete(AboutText aboutText)
        {
            _aboutTextDal.Delete(aboutText);
        }

        public AboutText GetAboutText()
        {
         
           return _aboutTextDal.GetAll().First();
        }

        public void Update(AboutText aboutText)
        {
            _aboutTextDal.Update(aboutText);
        }

      
    }
}
