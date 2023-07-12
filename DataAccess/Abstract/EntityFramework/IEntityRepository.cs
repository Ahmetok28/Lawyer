using System.Linq.Expressions;

namespace DataAccess.Abstract.EntityFramework
{
    public interface IEntityRepository<T> where T : class, new()
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
    }
}
