using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfAboutTextDal : EfEntityRepositoryBase<AboutText, Context>, IAboutTextDal
    {
    }
}
