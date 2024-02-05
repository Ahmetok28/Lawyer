using DataAccess.Conrete.EntityFramework;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Lawyer.Models;

namespace Lawyer.Helpers
{
    public class RouteValueTransformer : DynamicRouteValueTransformer
    {
        private readonly IActionDescriptorCollectionProvider _provider;
        IPracticeAreaService _practiceAreaService;

        public RouteValueTransformer(IActionDescriptorCollectionProvider provider, IPracticeAreaService practiceAreaService)
        {
            _provider = provider;
            _practiceAreaService = practiceAreaService;
        }
        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        {
            string url = null;
            string[] split = null;

            if (values["url"] == null)
            {
                return Home(values);
            }
            if (values["url"].ToString() == "BlogComment/AddComment" || values["url"].ToString() == "Message/AddMessage")
            {
                values.Remove("url");
                return values;
            }
            if (values["url"]!=null && UrlExistAdmin(url))
            {
                values.Remove("url");
                return values;
            }


            else
            {
                url = values["url"].ToString();
                split = url.Split('/');
                if (_provider.ActionDescriptors.Items.Any(c => c.AttributeRouteInfo != null && (split.Length > 1 ? c.AttributeRouteInfo.Template.ToLower().Contains($"/{split[1]}/") : c.AttributeRouteInfo.Template.ToLower().Contains(url))))
                {
                    values.Remove("url");
                    return values;
                }
            }
            if (url == string.Empty)
            {
                return Home(values);
            }
            else
            {
                url = Page(values, url);
                return await Web(values, url);
            }
        }

        protected RouteValueDictionary Home(RouteValueDictionary values)
        {
            values["controller"] = "Default";
            values["action"] = "Index";
            values.Remove("url");
            return values;
        }

        protected RouteValueDictionary Action(RouteValueDictionary values, string url)
        {
            IList<string> page = url.Split('/');
            values["controller"] = page[0];
            values["action"] = page[1];
            values["id"] = page[2];
            values.Remove("url");
            return values;
        }
        protected string Page(RouteValueDictionary values, string url)
        {
            IList<string> page = url.Split('_').ToList();
            if (page.Count > 1)
            {
                int index = page.Count - 1;
                url = url.Replace($"_{page[index]}", string.Empty);
                values["page"] = page[index];
            }

            return url;
        }
        protected async ValueTask<RouteValueDictionary> Web(RouteValueDictionary values, string url)
        {
            var urlmodel = new UrlModelView();
            var urls = urlmodel.GetUrlModel();
            if (url == urls.PracticeArea)
            {
                if (values["page"] == null) { values["page"] = "1"; }
                values["controller"] = "PracticeArea";
                values["action"] = "Index";
                values.Remove("url");
                return values;

            }
            if (url == urls.Blog)
            {
                if (values["page"] == null) { values["page"] = "1"; }
                values["controller"] = "Blog";
                values["action"] = "Index";
                values.Remove("url");
                return values;

            }
            if (url.StartsWith("bloglar/"))
            {
                int categoryId = GetCategoryIdFromUrl(url);

                if (values["page"] == null) { values["page"] = "1"; }
                values["controller"] = "Blog";
                values["action"] = "Index";
                values["categoryid"] = categoryId; 
                values.Remove("url");

                return values;
            }
            if (url == urls.About)
            {
                if (values["page"] == null) { values["page"] = "1"; }
                values["controller"] = "About";
                values["action"] = "Index";
                values.Remove("url");
                return values;

            }
            if (url == urls.Contact)
            {
                if (values["page"] == null) { values["page"] = "1"; }
                values["controller"] = "Contact";
                values["action"] = "Index";
                values.Remove("url");
                return values;

            }


            using Context context = new Context();
            PracticeArea practiceArea = await context.Practices.FirstOrDefaultAsync(x => x.Url == url || x.SeoUrl == url);
            if (practiceArea != null)
            {
                if (values["page"] == null) { values["page"] = "1"; }
                values["controller"] = "PracticeArea";
                values["action"] = "PracticeAreas";
                values["id"] = practiceArea.Id;
                values.Remove("url");
                return values;

            }

            UserAdditionalProperties user = await context.UserProperties.FirstOrDefaultAsync(x => x.SeoUrl == url);
            if (user != null)
            {
                if (values["page"] == null) { values["page"] = "1"; }
                values["controller"] = "About";
                values["action"] = "AboutMe";
                values["id"] = user.UserId;
                values.Remove("url");
                return values;
            }
            Blog blog = await context.Blogs.FirstOrDefaultAsync(x => x.SeoUrl == url);
            if (blog != null)
            {

                if (values["page"] == null) { values["page"] = "1"; }
                values["controller"] = "Blog";
                values["action"] = "SingleBlog";
                values["id"] = blog.BlogId;
                values.Remove("url");
                return values;

            }











            return values;


        }
        private int GetCategoryIdFromUrl(string url)
        {

            int categoryId = 0;
            var segments = url.Split('/');


            if (segments.Length >= 2 && segments[0] == "bloglar" && int.TryParse(segments[2], out categoryId))
            {
                return categoryId;
            }

            return 0;
        }

        private bool UrlExistAdmin(string url)
        {
            var segments = url.Split('/');
            return  segments.Contains("Admin");
        }
    }
}
