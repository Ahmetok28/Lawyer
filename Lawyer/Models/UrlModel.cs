using Business.Constants;

namespace Lawyer.Models
{
    public class UrlModel
    {
        public string Home { get; set; }
        public string About { get; set; }
        public string Contact { get; set; }
        public string PracticeArea { get; set; }
        public string Blog { get; set; }
    }
    public class UrlModelView
    {
        public UrlModel GetUrlModel()
        {
            return new UrlModel
            {
                Home = UrlConstants.Home,
                About = UrlConstants.About,
                Contact = UrlConstants.Contact,
                PracticeArea = UrlConstants.PracticeArea,
                Blog = UrlConstants.Blog
            };
        }
    }
}
