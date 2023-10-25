using DataAccess.Abstract;
using DataAccess.Abstract.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfPracticeAreaDal : EfEntityRepositoryBase<PracticeArea, Context>, IPracticeAreaDal
    {
    }
}
