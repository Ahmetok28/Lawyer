using Business.Abstract;
using Business.Constants;
using Bussines.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogCategoryManager : IBlogCategoryService
    {
        IBlogCategoryDal _blogCategoryDal;

        public BlogCategoryManager(IBlogCategoryDal blogCategoryDal)
        {
            _blogCategoryDal = blogCategoryDal;
        }
        [SecuredOperation("Admin,Editor,Yazar")]
        public IResult Add(BlogCategory blogCategory)
        {
            _blogCategoryDal.Add(blogCategory);
            return new SuccessResult(Messages.SuccesfullyAdded);
        }

        public IDataResult<BlogCategory> BlogCategoryGetById(int id)
        {
            return new SuccessDataResult<BlogCategory>(_blogCategoryDal.Get(x => x.Id == id));
        }
        [SecuredOperation("Admin,Editor,Yazar")]
        public IResult Delete(BlogCategory blogCategory)
        {
            _blogCategoryDal.Delete(blogCategory);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }


        public IDataResult<List<BlogCategory>> GetAll()
        {
            return new SuccessDataResult<List<BlogCategory>>(_blogCategoryDal.GetAll());
        }
        [SecuredOperation("Admin,Editor,Yazar")]
        public IResult Update(BlogCategory blogCategory)
        {
            _blogCategoryDal.Update(blogCategory);
            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
