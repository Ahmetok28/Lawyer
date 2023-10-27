using DataAccess.Abstract;
using DataAccess.Abstract.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfContactPageDal : EfEntityRepositoryBase<ContactPage, Context>, IContactPageDal
    {
    }
}
