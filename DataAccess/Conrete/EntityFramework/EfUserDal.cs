using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, Context>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new Context())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return result.ToList();
            }
        }
        public UserDto GetUserDetailById(int userId)
        {
            using (Context context = new Context())
            {
                var result = from u in context.Users.Where(u => u.Id == userId)
                             join o in context.UserOperationClaims
                             on u.Id equals o.UserId
                             join cl in context.OperationClaims
                             on o.OperationClaimId equals cl.Id

                             select new UserDto
                             {
                                 UserId = u.Id,
                                 ClaimId = cl.Id,

                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,

                                 ClaimName = cl.Name,

                             };
                return result.FirstOrDefault();
            }
        }
        public List<UserDto> GetUserDetails()
        {
            using (Context context = new Context())
            {
                var result = from u in context.Users
                             join o in context.UserOperationClaims
                             on u.Id equals o.UserId
                             join cl in context.OperationClaims
                             on o.OperationClaimId equals cl.Id
                             
                             select new UserDto
                             {
                                 UserId = u.Id,
                                 ClaimId = cl.Id,
                                
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 
                                 ClaimName = cl.Name,
                                
                             };
                return result.ToList();
            }
        }
    }
}
