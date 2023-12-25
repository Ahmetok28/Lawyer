using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        List<UserDto> GetUserDetails();
        UserDto GetUserDetailById(int userId);
        List<AuthorDTO> GetAuthors();
        AuthorDTO GetAuthor(int id);
    }
}
