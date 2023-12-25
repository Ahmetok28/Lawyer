using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IBlogCategoryService
    {
        IResult Add(BlogCategory blog);
        IResult Delete(BlogCategory blog);
        IResult Update(BlogCategory blog);
        IDataResult<List<BlogCategory>> GetAll();     
        IDataResult<BlogCategory> BlogCategoryGetById(int id);
    }
}
