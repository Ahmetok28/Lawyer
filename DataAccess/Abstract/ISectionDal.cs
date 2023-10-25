using DataAccess.Abstract.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ISectionDal : IEntityRepository<Section>
    {
    }
}
