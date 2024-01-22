using Business.Abstract;
using Business.Constants;
using Bussines.BusinessAspects.Autofac;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal _claimDal;

        public UserOperationClaimManager(IUserOperationClaimDal ClaimDal)
        {
            _claimDal = ClaimDal;
        }

        public IResult Add(UserOperationClaim claim)
        {
            _claimDal.Add(claim);
            return new SuccessResult(Messages.SuccesfullyAdded);
        }

       

        public IResult AddUser(User user)
        {
            UserOperationClaim claim = new UserOperationClaim()
            {

                UserId = user.Id
            };
            _claimDal.Add(claim);
            return new SuccessResult(Messages.SuccesfullyAdded);
        }

        public IResult Delete(UserOperationClaim claim)
        {
            _claimDal.Delete(claim);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public IResult DeleteUser(User user)
        {
            List<UserOperationClaim> claims = _claimDal.GetAll(c => c.Id == user.Id).ToList();
            foreach (var claim in claims)
            {
                _claimDal.Delete(claim);
            }
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_claimDal.GetAll());
        }

        public IDataResult<List<UserOperationClaim>> GetByClaimId(int id)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_claimDal.GetAll(c => c.OperationClaimId == id));
        }

        public IDataResult<List<UserOperationClaim>> GetByUserId(int id)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_claimDal.GetAll(c => c.UserId == id));
        }

        public IResult AddClaim(int userId, int roleId)
        {
            _claimDal.Add(new UserOperationClaim
            {
                UserId = userId,
                OperationClaimId = roleId
            });
            return new SuccessResult(Messages.SuccesfullyAdded);
        }
        public IResult RemoveAllClaimsByUserId(int userId)
        {
           _claimDal.RemoveAllByUserId(userId);
            return new SuccessResult();
        }

        [SecuredOperation("Admin")]
        public IResult Update(UserOperationClaim claim)
        {
            _claimDal.Update(claim);
            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
