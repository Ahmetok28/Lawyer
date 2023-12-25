using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IBlogCategoryDal : IEntityRepository<BlogCategory>
    {
    }
}
