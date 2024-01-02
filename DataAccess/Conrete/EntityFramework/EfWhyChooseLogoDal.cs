using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfWhyChooseLogoDal : EfEntityRepositoryBase<WhyChooseLogo, Context>, IWhyChooseLogoDal
    {
    }
}
