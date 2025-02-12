﻿using Business.Abstract;
using Business.Constants;
using Bussines.BusinessAspects.Autofac;
using Core.Aspect.Autofac.Caching;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Helpers.UrlHelper;
using Core.Utilities.Mail;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
        IFileHelper _fileHelper;
        IMailService _mailService;
        IEmailConfigurationService _emailConfigurationService;
        ISuscriberService _suscriberService;

        public BlogManager(IBlogDal blogDal, IFileHelper fileHelper, IEmailConfigurationService emailConfigurationService, ISuscriberService suscriberService, IMailService mailService)
        {
            _blogDal = blogDal;
            _fileHelper = fileHelper;
            _emailConfigurationService = emailConfigurationService;
            _suscriberService = suscriberService;
            _mailService = mailService;
        }
        [SecuredOperation("Admin,Editor,Yazar")]
        [CacheRemoveAspect("IBlogService.Get")]
        public IResult Add(IFormFile image, Blog blog)
        {
            blog.SeoUrl =  "blog/" + FriendlyUrlHelper.GetFriendlyTitle(blog.Title);
            blog.PhotoUrl = _fileHelper.Upload(image, PathConstants.Blogs);
            _blogDal.Add(blog);
            Task.Run(() => SendEmailsToSuscribers(blog.Title)); 
            return new SuccessResult(Messages.SuccesfullyAdded);
        }

        public IDataResult<Blog> BlogGetById(int id)
        {
            return new SuccessDataResult<Blog>(_blogDal.Get(x => x.BlogId == id));
        }
        [SecuredOperation("Admin,Editor,Yazar")]
        [CacheRemoveAspect("IBlogService.Get")]
        public IResult Delete(Blog blog)
        {
            _blogDal.Delete(blog);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Blog>> GetAll()
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<BlogDTO>> GetAllBlogDetails()
        {
            return new SuccessDataResult<List<BlogDTO>>(_blogDal.GetAllBlogDetails());
        }
        [CacheAspect]
        public IDataResult<BlogDTO> GetBlogDetailsById(int id)
        {
            return new SuccessDataResult<BlogDTO>(_blogDal.GetBlogDetailsByFilter(x => x.BlogId == id));
        }
        [CacheAspect]
        public IDataResult<List<BlogDTO>> GetBlogDetailsByCategoryId(int id)
        {
            return new SuccessDataResult<List<BlogDTO>>(_blogDal.GetAllBlogDetails(x => x.CategoryId == id));
        }
        [CacheAspect]
        public IDataResult<List<BlogDTO>> GetBlogDetailsByAuthorId(int id)
        {
            return new SuccessDataResult<List<BlogDTO>>(_blogDal.GetAllBlogDetails(x => x.AuthorId == id));
        }
        [CacheAspect]
        public IDataResult<List<BlogDTO>> GetBlogDetailsByCategoryAndAuthorId(int catId, int authId)
        {
            return new SuccessDataResult<List<BlogDTO>>(_blogDal.GetAllBlogDetails(x => x.CategoryId == catId && x.AuthorId == authId));
        }

        [SecuredOperation("Admin,Editor,Yazar")]
        [CacheRemoveAspect("IBlogService.Get")]
        public IResult Update(IFormFile image, Blog blog)
        {
            var check = IfImageIsNull(image);
            if (check.Success)
            {
                blog.PhotoUrl = blog.PhotoUrl = _fileHelper.Update(image, PathConstants.Blogs + blog.PhotoUrl, PathConstants.Blogs);
            }
            blog.PhotoUrl = _blogDal.Get(x => x.BlogId == blog.BlogId).PhotoUrl;
            blog.SeoUrl = "blog/"+ FriendlyUrlHelper.GetFriendlyTitle(blog.Title);
            _blogDal.Update(blog);
            return new SuccessResult(Messages.SuccesfullyUpdated);
        }

        public IDataResult<List<Blog>> BringLatestBlogs(int howMany)
        {
            var latestBlogs = _blogDal.GetAll()
          .OrderByDescending(blog => blog.CreatedDate)
          .Take(howMany)
          .ToList();

            return new SuccessDataResult<List<Blog>>(latestBlogs, "En son bloglar getirildi");
        }
        public IDataResult<List<Blog>> PrevAndNextBlogs(int id)
        {
            var allBlogs = _blogDal.GetAll().OrderByDescending(blog => blog.CreatedDate).ToList();

            var index = allBlogs.FindIndex(blog => blog.BlogId == id);

            if (index == -1)
            {
                return new ErrorDataResult<List<Blog>>("Belirtilen ID ile eşleşen blog bulunamadı.");
            }

            var prevBlog = index > 0 ? allBlogs[index - 1] : null;
            var nextBlog = index < allBlogs.Count - 1 ? allBlogs[index + 1] : null;

            var resultBlogs = new List<Blog>();

            if (prevBlog != null)
            {
                resultBlogs.Add(prevBlog);
            }

            resultBlogs.Add(allBlogs[index]);

            if (nextBlog != null)
            {
                resultBlogs.Add(nextBlog);
            }

            return new SuccessDataResult<List<Blog>>(resultBlogs, "Önceki ve sonraki bloglar getirildi");
        }

        public IDataResult<List<BlogDTO>> BringLatestBlogsDetails(int howMany)
        {
            var latestBlogs = _blogDal.GetAllBlogDetails()
          .OrderByDescending(blog => blog.BlogCreatedDate)
          .Take(howMany)
          .ToList();

            return new SuccessDataResult<List<BlogDTO>>(latestBlogs, "En son bloglar getirildi");
        }

        private IResult IfImageIsNull(IFormFile file)
        {
            if (file == null)
            {
                return new ErrorResult(); ;
            }
            return new SuccessResult();
        }

        private async void SendEmailsToSuscribers(string blogName)
        {
            var users = _suscriberService.GetAll().Data;// Veritabanından kullanıcıları çek

            EmailConfiguration mailconfig = _emailConfigurationService.Get().Data;



            foreach (var user in users)
            {
                var message = new MailMessage
                {
                    Body = blogName + " İsiminde " + "yeni bir blog eklenmiştir. Bloğu incelemek için web sitemizi ziyaret edin.",
                    Subject = "Yeni Blog Eklendi",
                    ToMailAddres = user.EMail
                };


               await _mailService.SendEmail(message, mailconfig);
                


            }
        }

        public IDataResult<List<BlogDTO>> GetBlogDetailsByCategoryName(string name)
        {
            return new SuccessDataResult<List<BlogDTO>>(_blogDal.GetAllBlogDetails(x => x.CategoryName == name));
        }
    }
}
