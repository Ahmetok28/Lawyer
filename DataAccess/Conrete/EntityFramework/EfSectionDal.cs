using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfSectionDal : EfEntityRepositoryBase<Section, Context>, ISectionDal
    {
    }
}
