using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IUserAdditionalPropertiesDal : IEntityRepository<UserAdditionalProperties>
    {
        List<UserForTeamDTO> GetAllUserDetails(Expression<Func<UserForTeamDTO, bool>> filter = null);
        UserForTeamDTO GetUserDetailsByFilter(Expression<Func<UserForTeamDTO, bool>> filter);
    }
}
