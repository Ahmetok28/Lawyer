﻿using Business.Abstract;
using Business.Constants;
using Bussines.BusinessAspects.Autofac;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private IUserOperationClaimService _claimService;
        


        public UserManager(IUserDal userDal, IUserOperationClaimService claimService)
        {
            _userDal = userDal;
            _claimService = claimService;
            
        }
        [SecuredOperation("Admin")]
        public IResult Add(User user)
        {
            var check = CheckOtherEmail(user.Email);

            var result = BusinessRules.Run(check);

            if (result != null)
            {
                return result;
            }

            _userDal.Add(user);
            return new SuccessResult(Messages.SuccesfullyAdded);
        }
        [SecuredOperation("Admin")]
        public IResult Delete(User user)
        {
           
            _claimService.DeleteUser(user);
            _userDal.Delete(user);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public IDataResult<User> Get(int id)
        {
           return new SuccessDataResult<User>(_userDal.Get(x=>x.Id== id));
        }

        [SecuredOperation("Admin")]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<AuthorDTO> GetAuthor(int id)
        {
            return new SuccessDataResult<AuthorDTO>(_userDal.GetAuthor(id));
        }

        public IDataResult<List<AuthorDTO>> GetAuthors()
        {
            return new SuccessDataResult<List<AuthorDTO>>(_userDal.GetAuthors());
        }

        public IDataResult<User> GetByMail(string email)
        {
            var value = _userDal.Get(u => u.Email == email && u.Status==true);

            return new SuccessDataResult<User>(value);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<UserDto> GetUserDetailById(int userId)
        {
            return new SuccessDataResult<UserDto>(_userDal.GetUserDetailById(userId));
        }

        public IDataResult<List<UserDto>> GetUserDetails()
        {
            return new SuccessDataResult<List<UserDto>>(_userDal.GetUserDetails());
        }
        [SecuredOperation("Admin,Editor,Yazar,User")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
        private IResult CheckOtherEmail(string email)
        {
            var result = _userDal.GetAll(u => u.Email == email).Any();
            if (result)
            {
                return new ErrorResult(Messages.EmailInvalid);
            }

            return new SuccessResult();
        }
    }
}
