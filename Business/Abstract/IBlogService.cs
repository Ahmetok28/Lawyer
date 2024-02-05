using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService
    {
        IResult Add(IFormFile image, Blog blog);
        IResult Delete(Blog blog);
        IResult Update(IFormFile image, Blog blog);
        IDataResult<List<Blog>> GetAll();
        IDataResult<List<Blog>> BringLatestBlogs(int howMany);
        IDataResult<List<BlogDTO>> BringLatestBlogsDetails(int howMany);
        IDataResult<List<BlogDTO>> GetAllBlogDetails();
        IDataResult<BlogDTO> GetBlogDetailsById(int id);
        IDataResult<List<BlogDTO>> GetBlogDetailsByAuthorId(int id);
        IDataResult<List<BlogDTO>> GetBlogDetailsByCategoryId(int id);
        IDataResult<List<BlogDTO>> GetBlogDetailsByCategoryName(string name);
        IDataResult<List<BlogDTO>> GetBlogDetailsByCategoryAndAuthorId(int catId,int authId);
        IDataResult<Blog> BlogGetById(int id);
        IDataResult<List<Blog>> PrevAndNextBlogs(int id);
    } 
}
