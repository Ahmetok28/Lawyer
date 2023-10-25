using DataAccess.Abstract;
using DataAccess.Abstract.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfMessageDal : EfEntityRepositoryBase<Message, Context>, IMessageDal
    {
    }
}
