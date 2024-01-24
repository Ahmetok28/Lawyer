using HtmlAgilityPack;
using System.Net;

namespace Lawyer.Helpers
{
    public static class HtmlUtilities
    {
        public static string StripHtml(string html)
        {
            if (html == null)
                return string.Empty;

            string decodedHtml = WebUtility.HtmlDecode(html);

            var doc = new HtmlDocument();
            doc.LoadHtml(decodedHtml);

            return doc.DocumentNode.InnerText;
        }
    }
}
