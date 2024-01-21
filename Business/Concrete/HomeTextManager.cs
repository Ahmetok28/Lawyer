using Business.Abstract;
using Business.Constants;
using Bussines.BusinessAspects.Autofac;
using Core.Entities.Concrete;
using Core.Utilities.Business;
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
    public class HomeTextManager:IHomeTextService
    {
        private readonly IHomeTextDal _homeTextDal;
        IFileHelper _fileHelper;

        public HomeTextManager(IHomeTextDal homeTextDal, IFileHelper fileHelper)
        {
            _homeTextDal = homeTextDal;
            _fileHelper = fileHelper;
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Add(HomeText homeText)
        {
            _homeTextDal.Add(homeText);
            return new SuccessResult(Messages.SuccesfullyAdded);
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Delete(HomeText homeText)
        {
            _homeTextDal.Delete(homeText);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public IDataResult< HomeText> GetHomeText()
        {
            return  new SuccessDataResult<HomeText>( _homeTextDal.GetAll().First());
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Update(IFormFile file ,HomeText homeText)
        {
            var check = IfImageIsNull(file);

           

            if (check.Success)
            {
                homeText.BackroundImage = _fileHelper.Update(file, PathConstants.UIHomePage + homeText.BackroundImage, PathConstants.UIHomePage);
            }
            
            _homeTextDal.Update(homeText);
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
