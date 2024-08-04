using Business.Abstract;
using Business.Constants;
using Bussines.BusinessAspects.Autofac;
using Core.Aspect.Autofac.Caching;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Helpers.UrlHelper;
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
        [SecuredOperation("Admin,Editor")]
        [CacheRemoveAspect("IAboutTextService.Get")]
        public IResult Add(AboutText aboutText)
        {           
            _aboutTextDal.Add(aboutText);
            return new SuccessResult(Messages.SuccesfullyAdded);
        }
        [SecuredOperation("Admin,Editor")]
        [CacheRemoveAspect("IAboutTextService.Get")]
        public IResult Delete(AboutText aboutText)
        {
            _aboutTextDal.Delete(aboutText);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        [CacheAspect]
        public IDataResult< AboutText> GetAboutText()
        {
         
           return new SuccessDataResult<AboutText>(_aboutTextDal.GetAll().First());
        }
        [SecuredOperation("Admin,Editor")]
        [CacheRemoveAspect("IAboutTextService.Get")]
        public IResult Update(IFormFile file, AboutText aboutText)
        {
            var check = IfImageIsNull(file);



            if (check.Success)
            {
                aboutText.Image = _fileHelper.Update(file, PathConstants.UIHomePage + aboutText.Image, PathConstants.UIHomePage);
            }
            else
            {
              var abaout=  _aboutTextDal.Get(x=>x.Id==aboutText.Id);
                aboutText.Image = abaout.Image;
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
