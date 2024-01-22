using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProfilePhotoManager : IProfilePhotoService
    {

        IProfilePhotoDal _profilePhotoDal;
        IFileHelper _fileHelper;

        public ProfilePhotoManager(IProfilePhotoDal profilePhotoDal, IFileHelper fileHelper)
        {
            _profilePhotoDal = profilePhotoDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(IFormFile file, ProfilePhoto profilePhoto)
        {

            profilePhoto.ImagePath = PathConstants.ProfilePhotoPath+ _fileHelper.Upload(file, PathConstants.ProfilePhotoPath);
            profilePhoto.Date = DateTime.Now;
            _profilePhotoDal.Add(profilePhoto);
            return new SuccessResult("Resim başarıyla yüklendi");
        }
        public IResult AddOnlyPhoto(ProfilePhoto profilePhoto)
        {
            profilePhoto.ImagePath = "default.png";
            profilePhoto.Date = DateTime.Now;
            _profilePhotoDal.Add(profilePhoto);
            return new SuccessResult();
        }
        public IResult Delete(ProfilePhoto profilePhoto)
        {
            _fileHelper.Delete(PathConstants.ProfilePhotoPath + profilePhoto.ImagePath);
            _profilePhotoDal.Delete(profilePhoto);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public IDataResult<List<ProfilePhoto>> GetAll()
        {
            return new SuccessDataResult<List<ProfilePhoto>>(_profilePhotoDal.GetAll());
        }

        public IDataResult<ProfilePhoto> GetById(int id)
        {
            return new SuccessDataResult<ProfilePhoto>(_profilePhotoDal.Get(p => p.Id == id));
        }

        public IDataResult<ProfilePhoto> GetByUserId(int id)
        {
            var result = BusinessRules.Run(CheckIfProfilePhotoNull(id));
            if (result != null)
            {
                return new ErrorDataResult<ProfilePhoto>(GetDefaultImage(id).Data);
            }
            return new SuccessDataResult<ProfilePhoto>(_profilePhotoDal.Get(p => p.UserId == id));
        }

        public IResult Update(IFormFile formFile, ProfilePhoto profilePhoto)
        {
            profilePhoto.ImagePath =  _fileHelper.Update(formFile, PathConstants.ProfilePhotoPath + profilePhoto.ImagePath, PathConstants.ProfilePhotoPath);
            _profilePhotoDal.Update(profilePhoto);
            return new SuccessResult();
        }
        private IDataResult<ProfilePhoto> GetDefaultImage(int imageId)
        {

            ProfilePhoto profilePhoto = new ProfilePhoto();
            profilePhoto.ImagePath = "default.png";
            profilePhoto.Id = imageId;
            profilePhoto.Date = DateTime.Now;
            
            return new SuccessDataResult<ProfilePhoto>(profilePhoto);
        }

        private IResult CheckIfProfilePhotoNull(int id)
        {
            var result = _profilePhotoDal.GetAll(p => p.UserId == id).Any();
            if (result)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
