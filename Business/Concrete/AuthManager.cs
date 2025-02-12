﻿using Business.Abstract;
using Business.Constants;
using Bussines.BusinessAspects.Autofac;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IUserAdditioanlPropertiesService _additioanlPropertiesService;
        private IProfilePhotoService _profilePhotoService;
       
        private IUserOperationClaimService _claimService;

        public AuthManager(IUserOperationClaimService claimService)
        {
            _claimService = claimService;
        }

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimService claimService, IUserAdditioanlPropertiesService additioanlPropertiesService , IProfilePhotoService profilePhotoService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;

            _claimService = claimService;
            _additioanlPropertiesService = additioanlPropertiesService;
            _profilePhotoService = profilePhotoService;
        }

        [SecuredOperation("Admin")]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);

            _claimService.Add(new UserOperationClaim
            {
                UserId = user.Id,
                OperationClaimId = 4
            }) ;
            _additioanlPropertiesService.Add(new UserAdditionalProperties
            {
                UserId= user.Id,
                TeamStatus=false,
                
                
            });
            _profilePhotoService.AddOnlyPhoto(new ProfilePhoto
            {
                UserId=user.Id
            });

            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            var user = _userService.GetByMail(email);
            if (user.Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IResult ChangePassword(ChangePasswordDTO changePassword)
        {
            var userToCheck = _userService.GetByMail(changePassword.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorResult(Messages.EMailNotMatch);
            }
            if (!HashingHelper.VerifyPasswordHash(changePassword.CurrentPassword, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorResult(Messages.PasswordNotMatch);
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(changePassword.NewPassword, out passwordHash, out passwordSalt);
           
            userToCheck.PasswordHash = passwordHash;
            userToCheck.PasswordSalt = passwordSalt;
            
           _userService.Update(userToCheck);

            return new SuccessResult(Messages.PasswordchangeSuccessful);
        }
    }
}
