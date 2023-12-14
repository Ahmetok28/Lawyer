using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPostService
    {
        void Add(Post post);
        void Delete(Post post);
        void Update(Post post);
        List<Post> GetAll();
        List<Post> GetById(int id);
    }
}
