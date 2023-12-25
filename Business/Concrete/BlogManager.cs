using Business.Abstract;
using Business.Constants;
using Bussines.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Add(Blog blog)
        {
           _blogDal.Add(blog);
            return new SuccessResult(Messages.SuccesfullyAdded);
        }

        public IDataResult< Blog> BlogGetById(int id)
        {
            return  new SuccessDataResult<Blog>( _blogDal.Get(x => x.BlogId == id)) ;
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Delete(Blog blog)
        {
            _blogDal.Delete(blog);
            return new SuccessResult(Messages.SuccesfullyDeleted) ;
        }

       
        public IDataResult< List<Blog>> GetAll()
        {
           return new SuccessDataResult<List<Blog>>( _blogDal.GetAll());    
        }

        public IDataResult<List<BlogDTO>> GetAllBlogDetails()
        {
            return new SuccessDataResult<List<BlogDTO>>(_blogDal.GetAllBlogDetails());
        }

        public IDataResult<BlogDTO> GetBlogDetailsById(int id)
        {
            return new SuccessDataResult<BlogDTO>(_blogDal.GetBlogDetailsByFilter(x=>x.BlogId==id));
        } 
        public IDataResult<List<BlogDTO>> GetBlogDetailsByCategoryId(int id)
        {
            return new SuccessDataResult<List<BlogDTO>>(_blogDal.GetAllBlogDetails(x => x.CategoryId==id));
        } 
        public IDataResult<List<BlogDTO>> GetBlogDetailsByAuthorId(int id)
        {
            return new SuccessDataResult<List<BlogDTO>>(_blogDal.GetAllBlogDetails(x=>x.AuthorId==id));
        } 
        public IDataResult<List<BlogDTO>> GetBlogDetailsByCategoryAndAuthorId(int catId,int authId)
        {
            return new SuccessDataResult<List<BlogDTO>>(_blogDal.GetAllBlogDetails(x=>x.CategoryId==catId && x.AuthorId==authId));
        }

        [SecuredOperation("Admin,Moderator")]
        public IResult Update(Blog blog)
        {
            _blogDal.Update(blog);
            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
