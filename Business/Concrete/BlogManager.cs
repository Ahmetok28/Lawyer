﻿using Business.Abstract;
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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        [SecuredOperation("Admin,Moderator")]
        public void Add(Blog blog)
        {
           _blogDal.Add(blog);
        }

        public Blog BlogGetById(int id)
        {
            throw new NotImplementedException();
        }
        [SecuredOperation("Admin,Moderator")]
        public void Delete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

       
        public List<Blog> GetAll()
        {
           return _blogDal.GetAll();    
        }
        [SecuredOperation("Admin,Moderator")]
        public void Update(Blog blog)
        {
            _blogDal.Update(blog);
        }
    }
}
