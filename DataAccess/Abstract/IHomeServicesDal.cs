using DataAccess.Abstract.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IHomeServicesDal : IEntityRepository<HomeServices>
    {
    }
    public interface IMessageDal : IEntityRepository<Message>
    {
    }
}
