using Core.DataAccess;
using Core.Entities;
using Core.Entities.Concrete;
using DataAccess.Conrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>
    {
        public void RemoveAllByUserId(int userId)
        {
            using (Context context = new Context())
            {
                var userClaimsToRemove = context.UserOperationClaims
                .Where(uoc => uoc.UserId == userId)
                .ToList();
                context.UserOperationClaims.RemoveRange(userClaimsToRemove);
                context.SaveChanges();
            }
        }
    }
}
