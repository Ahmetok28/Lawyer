using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfFooterSocialAndSayingDal : EfEntityRepositoryBase<FooterSocialAndSaying, Context>, IFooterSocialAndSayingDal
    {
    }
}
