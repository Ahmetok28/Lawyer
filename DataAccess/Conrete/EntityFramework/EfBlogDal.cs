using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfBlogDal : EfEntityRepositoryBase<Blog, Context>, IBlogDal
    {
        public List<BlogDTO> GetAllBlogDetails(Expression<Func<BlogDTO, bool>> filter = null)
        {
            using(Context context= new Context())
            {
                var results = from blog in context.Blogs
                              join category in context.BlogCategories
                              on blog.CategoryId equals category.Id
                              join auth in context.Users
                              on blog.AuthorId equals auth.Id
                              join userAddProp in context.UserProperties
                              on auth.Id equals userAddProp.UserId
                              select new BlogDTO
                              {
                                  BlogId = blog.BlogId,
                                  CategoryId = category.Id,
                                  AuthorId = auth.Id,
                                  CategoryName = category.Name,
                                  AuthorFullName = auth.FirstName + " " + auth.LastName,
                                  SeoUrl=blog.SeoUrl,
                                  AuthorSeoUrl=userAddProp.SeoUrl,
                                  BlogContent = blog.Content,
                                  BlogCreatedDate = blog.CreatedDate,
                                  BlogDescription = blog.Description,
                                  BlogTitle = blog.Title,
                                  BlogPhoto = blog.PhotoUrl
                              };
                return filter == null ? results.ToList()
                                      : results.Where(filter).ToList();
                                    
            }
        }

        public BlogDTO GetBlogDetailsByFilter(Expression<Func<BlogDTO, bool>> filter )
        {
            using (Context context = new Context())
            {
                var result = from blog in context.Blogs
                              join category in context.BlogCategories
                              on blog.CategoryId equals category.Id
                              join auth in context.Users
                              on blog.AuthorId equals auth.Id
                             join userAddProp in context.UserProperties
                            on auth.Id equals userAddProp.UserId
                             select new BlogDTO
                              {
                                  BlogId = blog.BlogId,
                                  CategoryId = category.Id,
                                  AuthorId = auth.Id,
                                  CategoryName = category.Name,
                                  AuthorFullName = auth.FirstName +" "+ auth.LastName,
                                  SeoUrl=blog.SeoUrl,
                                 AuthorSeoUrl = userAddProp.SeoUrl,
                                 BlogContent = blog.Content,
                                  BlogCreatedDate = blog.CreatedDate,
                                  BlogDescription = blog.Description,
                                  BlogTitle = blog.Title,
                                  BlogPhoto = blog.PhotoUrl
                              };
                return result.SingleOrDefault(filter);

            }
        }
    }
}
