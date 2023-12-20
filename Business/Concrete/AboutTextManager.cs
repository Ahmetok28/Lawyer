using Business.Abstract;
using Bussines.BusinessAspects.Autofac;
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
        [SecuredOperation("Admin,Moderator")]
        public void Add(AboutText aboutText)
        {
            _aboutTextDal.Add(aboutText);
        }
        [SecuredOperation("Admin,Moderator")]
        public void Delete(AboutText aboutText)
        {
            _aboutTextDal.Delete(aboutText);
        }

        public AboutText GetAboutText()
        {
         
           return _aboutTextDal.GetAll().First();
        }
        [SecuredOperation("Admin,Moderator")]
        public void Update(AboutText aboutText)
        {
            _aboutTextDal.Update(aboutText);
        }

      
    }
}
