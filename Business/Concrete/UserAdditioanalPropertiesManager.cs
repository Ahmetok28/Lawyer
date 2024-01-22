using Business.Abstract;
using Bussines.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserAdditioanalPropertiesManager : IUserAdditioanlPropertiesService     

    {
        private readonly IUserAdditionalPropertiesDal _userAdditionalPropertiesDal;

        public UserAdditioanalPropertiesManager(IUserAdditionalPropertiesDal userAdditionalPropertiesDal)
        {
            _userAdditionalPropertiesDal = userAdditionalPropertiesDal;
        }
        [SecuredOperation("Admin")]
        public IResult Add(UserAdditionalProperties userAdditional)
        {
           _userAdditionalPropertiesDal.Add(userAdditional);
            return new SuccessResult();
        }
        [SecuredOperation("Admin")]
        public IResult Delete(UserAdditionalProperties userAdditional)
        {
           _userAdditionalPropertiesDal.Delete(userAdditional);
            return new SuccessResult();
        }
        
        public IDataResult< List<UserAdditionalProperties>> GetAll()
        {
           return new SuccessDataResult<List<UserAdditionalProperties>>( _userAdditionalPropertiesDal.GetAll());
        }

        public IDataResult<List<UserForTeamDTO>> GetAllDetails()
        {
            return new SuccessDataResult<List<UserForTeamDTO>>(_userAdditionalPropertiesDal.GetAllUserDetails());
        }

        public IDataResult<List<UserAdditionalProperties>> GetAllIfTeamMemberExists(bool teamMember)
        {
            return new SuccessDataResult<List<UserAdditionalProperties>>(_userAdditionalPropertiesDal.GetAll(x=>x.TeamStatus==true));
        }

        public IDataResult<List<UserForTeamDTO>> GetAllIfTeamMemberExistsDto()
        {
            return new SuccessDataResult<List<UserForTeamDTO>>(_userAdditionalPropertiesDal.GetAllUserDetails(x => x.TeamStatus == true));
        }

        public IDataResult<UserForTeamDTO> GetByIdDto(int id)
        {
            return new SuccessDataResult<UserForTeamDTO>(_userAdditionalPropertiesDal.GetUserDetailsByFilter(x => x.UserId == id && x.TeamStatus == true));
        }
         public IDataResult<UserForTeamDTO> GetByIdDtoForAdminPanel(int id)
        {
            return new SuccessDataResult<UserForTeamDTO>(_userAdditionalPropertiesDal.GetUserDetailsByFilter(x => x.UserId == id));
        }

        public IDataResult< UserAdditionalProperties> GetByUserId(int userId)
        {
           return new SuccessDataResult<UserAdditionalProperties>( _userAdditionalPropertiesDal.Get(x=>x.UserId==userId));
        }
        [SecuredOperation("Admin,Moderator,Editor,Yazar,User")]
        public IResult Update(UserAdditionalProperties userAdditional)
        {
           _userAdditionalPropertiesDal.Update(userAdditional);
            return new SuccessResult();
        }
    }
}
