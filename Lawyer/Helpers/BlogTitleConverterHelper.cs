using Entities.Concrete;
using Lawyer.Models;
using System.Collections.Generic;

namespace Lawyer.Helpers
{



    public static class BlogTitleConverterHelper
    {
        public static List<RecentBlogViewModel> ConvertToBlogViewModel(List<Blog> blogList, int wordCount)
        {
            List<RecentBlogViewModel> recentBlogs = new List<RecentBlogViewModel>();

            foreach (var blog in blogList)
            {
                var model = ConvertToBlogViewModel(blog, wordCount);
                recentBlogs.Add(model);
            }

            return recentBlogs;
        }

        private static RecentBlogViewModel ConvertToBlogViewModel(Blog blog, int wordCount)
        {
            return new RecentBlogViewModel
            {
                Id = blog.BlogId,
                Title = !string.IsNullOrEmpty(blog.Title) && blog.Title.Length > wordCount
                            ? blog.Title[..wordCount]
                            : blog.Title,
                ImageUrl = blog.PhotoUrl,
                CreatedDate = blog.CreatedDate.ToString("dd MMMM yyyy")
            };
        }
    }
}
