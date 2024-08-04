using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfAboutPageDal : EfEntityRepositoryBase<AboutPage, Context>, IAboutPageDal
    {
    }
}
