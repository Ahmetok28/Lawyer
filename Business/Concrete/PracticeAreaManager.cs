using Business.Abstract;
using Business.Constants;
using Bussines.BusinessAspects.Autofac;
using Core.Aspect.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Helpers.UrlHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PracticeAreaManager:IPracticeAreaService
    {
        private readonly IPracticeAreaDal _practiceAreaDal;
        IFileHelper _fileHelper;
        public PracticeAreaManager(IPracticeAreaDal practiceAreaDal, IFileHelper fileHelper)
        {
            _practiceAreaDal = practiceAreaDal;
            _fileHelper = fileHelper;
        }
        [SecuredOperation("Admin,Editor")]
        [CacheRemoveAspect("IPracticeAreaService.Get")]
        public IResult Add(IFormFile image, IFormFile background, PracticeArea practiceArea)
        {
            practiceArea.Image =  _fileHelper.Upload(image, PathConstants.PracticeArea);
            practiceArea.BackgroundImage =  _fileHelper.Upload(background, PathConstants.PracticeArea);

            practiceArea.SeoUrl = UrlConstants.PracticeArea + "/" + FriendlyUrlHelper.GetFriendlyTitle(practiceArea.Name);
            _practiceAreaDal.Add(practiceArea);
            return new SuccessResult(Messages.SuccesfullyAdded);
        }
        [SecuredOperation("Admin,Editor")]
        [CacheRemoveAspect("IPracticeAreaService.Get")]
        public IResult Delete(PracticeArea practiceArea)
        {
            _practiceAreaDal.Delete(practiceArea);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        [CacheAspect]
        public IDataResult< List<PracticeArea>> GetAll()
        {
            return new SuccessDataResult<List<PracticeArea>>( _practiceAreaDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<PracticeAreaDTO>> GetTitleAndId()
        {
            var value= _practiceAreaDal.GetAll().Select(x => new PracticeAreaDTO { Id = x.Id, Name = x.Name }).ToList();
            return new SuccessDataResult<List<PracticeAreaDTO>>( value);
        }

        public IDataResult<PracticeArea>  GetById(int id)
        {
           return new SuccessDataResult<PracticeArea>( _practiceAreaDal.Get(x=>x.Id == id));
        }

        [SecuredOperation("Admin,Editor")]
        [CacheRemoveAspect("IPracticeAreaService.Get")]
        public IResult Update(IFormFile image, IFormFile backgroud, PracticeArea practiceArea)
        {
            var checkImage=IfImageIsNull(image);
            var checkBackGround=IfImageIsNull(backgroud);

            if (checkImage.Success)
            {
                practiceArea.Image =_fileHelper.Update(image, PathConstants.PracticeArea + practiceArea.Image, PathConstants.PracticeArea);
            }  
            if (checkBackGround.Success)
            {
                practiceArea.BackgroundImage =  _fileHelper.Update(backgroud,PathConstants.PracticeArea+ practiceArea.BackgroundImage, PathConstants.PracticeArea);
            }

            practiceArea.SeoUrl = UrlConstants.PracticeArea + "/" + FriendlyUrlHelper.GetFriendlyTitle(practiceArea.Name);
            _practiceAreaDal.Update(practiceArea);
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
