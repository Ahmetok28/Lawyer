using Business.Abstract;
using Bussines.BusinessAspects.Autofac;
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
        [SecuredOperation("Admin,Moderator")]
        public void Add(Post post)
        {
           _postDal.Add(post);
        }
        [SecuredOperation("Admin,Moderator")]
        public void Update(Post post)
        {
            _postDal.Update(post);
        }
        [SecuredOperation("Admin,Moderator")]
        public void Delete(Post post)
        {
            _postDal.Delete(post);
        }

        public List<Post> GetAll()
        {
            return _postDal.GetAll();   
        }

        public List<Post> GetById(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
