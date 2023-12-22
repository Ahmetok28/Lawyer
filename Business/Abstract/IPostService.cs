using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPostService
    {
        IResult Add(Post post);
        IResult Delete(Post post);
        IResult Update(Post post);
        IDataResult<List<Post>> GetAll();
         IDataResult<Post> GetById(int id);
    }
}
