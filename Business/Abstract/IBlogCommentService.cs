using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBlogCommentService
    {
        IResult Add(BlogComment blogComment);
        IResult Delete(BlogComment blogComment);
        IResult Update(BlogComment blogComment);
        IDataResult<List<BlogComment>> GetAll();
        IDataResult<BlogComment> BlogCommentGetById(int id);
        IDataResult<List<BlogComment>> BlogCommentsGetAllByBlogId(int id);
    } 
}
