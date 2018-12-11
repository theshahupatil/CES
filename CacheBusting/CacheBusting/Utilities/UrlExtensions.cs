using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace CacheBusting.Utilities
{
    public static class UrlExtensions
    {
        public static string DatedContent(this UrlHelper urlHelper, string contentPath)
        {

            var datedPath = new StringBuilder(contentPath);
            datedPath.AppendFormat("{0}m={1}",
                                   contentPath.IndexOf('?') >= 0 ? '&' : '?',
                                   getModifiedDate(contentPath));
            return urlHelper.Content(datedPath.ToString());
        }

        private static string getModifiedDate(string contentPath)
        {
            return System.IO.File.GetLastWriteTime(HostingEnvironment.MapPath(contentPath)).ToString("yyyyMMddhhmmss");
        }
    }
}