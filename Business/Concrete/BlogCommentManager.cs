using Business.Abstract;
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
    public class BlogCommentManager : IBlogCommentService
    {
        private readonly IBlogCommentDal _blogCommentDal;

        public BlogCommentManager(IBlogCommentDal blogCommentDal)
        {
            _blogCommentDal = blogCommentDal;
        }

        public IResult Add(BlogComment blogComment)
        {
           _blogCommentDal.Add(blogComment);
            return new SuccessResult();
        }

        public IDataResult<BlogComment> BlogCommentGetById(int id)
        {
            return new SuccessDataResult<BlogComment>(_blogCommentDal.Get(x=>x.Id==id));
        }
        public IDataResult< List<BlogComment> >BlogCommentsGetAllByBlogId(int blogId)
        {
            return new SuccessDataResult<List<BlogComment>>(_blogCommentDal.GetAll(x=>x.BlogId==blogId));
        }

        public IResult Delete(BlogComment blogComment)
        {
            _blogCommentDal.Delete(blogComment);
            return new SuccessResult();
        }

        public IDataResult<List<BlogComment>> GetAll()
        {
            return new SuccessDataResult<List<BlogComment>>(_blogCommentDal.GetAll());
        }

        public IResult Update(BlogComment blogComment)
        {
            _blogCommentDal.Update(blogComment);
            return new SuccessResult();
        }
    }
}
