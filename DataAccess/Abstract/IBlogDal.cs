using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IBlogDal : IEntityRepository<Blog>
    {
        List<BlogDTO> GetAllBlogDetails(Expression<Func<BlogDTO, bool>> filter = null);
        BlogDTO GetBlogDetailsByFilter(Expression<Func<BlogDTO, bool>> filter);
    }
}
