using Business.Abstract;
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
    public class PostManager : IPostService
    {
        IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }
        [SecuredOperation("Admin,Editor")]
        public IResult Add(Post post)
        {
           _postDal.Add(post);
            return new SuccessResult();
        }
        [SecuredOperation("Admin,Editor")]
        public IResult Update(Post post)
        {
            _postDal.Update(post);
            return new SuccessResult();
        }
        [SecuredOperation("Admin,Editor")]
        public IResult Delete(Post post)
        {
            _postDal.Delete(post);
            return new SuccessResult();
        }

        public IDataResult< List<Post>> GetAll()
        {
            return new SuccessDataResult<List<Post>>( _postDal.GetAll());   
        }

        public IDataResult<Post> GetById(int id)
        {
            return new SuccessDataResult<Post>(_postDal.Get(x => x.PostId == id));
        }

        
    }
}
