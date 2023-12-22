using Business.Abstract;
using Bussines.BusinessAspects.Autofac;
using Core.Utilities.Results;
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
        public IResult Add(AboutText aboutText)
        {
            _aboutTextDal.Add(aboutText);
            return new SuccessResult();
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Delete(AboutText aboutText)
        {
            _aboutTextDal.Delete(aboutText);
            return new SuccessResult();
        }

        public IDataResult< AboutText> GetAboutText()
        {
         
           return new SuccessDataResult<AboutText>(_aboutTextDal.GetAll().First());
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Update(AboutText aboutText)
        {
             _aboutTextDal.Update(aboutText);
           return new SuccessResult();
        }

      
    }
}
