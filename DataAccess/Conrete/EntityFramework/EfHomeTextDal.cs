using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfHomeTextDal: EfEntityRepositoryBase<HomeText,Context>, IHomeTextDal
    {
    }
}
