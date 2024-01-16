using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserAdditioanlPropertiesService
    {
        IResult Add(UserAdditionalProperties userAdditionalProperties);
        IResult Update(UserAdditionalProperties userAdditionalProperties);
        IResult Delete(UserAdditionalProperties userAdditionalProperties);
        IDataResult<UserAdditionalProperties> GetByUserId(int userId);
        IDataResult<List<UserAdditionalProperties>> GetAll();
        IDataResult<List<UserAdditionalProperties>> GetAllIfTeamMemberExists(bool teamMember);
        IDataResult<List<UserForTeamDTO>> GetAllDetails();
        IDataResult<List<UserForTeamDTO>> GetAllIfTeamMemberExistsDto();
        IDataResult<UserForTeamDTO> GetByIdDto(int id);



    }
}
