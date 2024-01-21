using Business.Abstract;
using Business.Constants;
using Bussines.BusinessAspects.Autofac;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
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
        IFileHelper _fileHelper;
        public AboutTextManager(IAboutTextDal aboutTextDal, IFileHelper fileHelper)
        {
            _aboutTextDal = aboutTextDal;
            _fileHelper = fileHelper;
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Add(AboutText aboutText)
        {
            _aboutTextDal.Add(aboutText);
            return new SuccessResult(Messages.SuccesfullyAdded);
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Delete(AboutText aboutText)
        {
            _aboutTextDal.Delete(aboutText);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public IDataResult< AboutText> GetAboutText()
        {
         
           return new SuccessDataResult<AboutText>(_aboutTextDal.GetAll().First());
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Update(IFormFile file, AboutText aboutText)
        {
            var check = IfImageIsNull(file);



            if (check.Success)
            {
                aboutText.Image = _fileHelper.Update(file, PathConstants.UIHomePage + aboutText.Image, PathConstants.UIHomePage);
            }
            _aboutTextDal.Update(aboutText);
           return new SuccessResult(Messages.SuccesfullyUpdated);
        }

        private IResult IfImageIsNull(IFormFile file)
        {
            if (file == null)
            {
                return new ErrorResult(); ;
            }
            return new SuccessResult();
        }
    }
}
