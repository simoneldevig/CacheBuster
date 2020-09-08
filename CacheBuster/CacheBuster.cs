using System;
using System.IO;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace CacheBuster
{
    public static class CacheBuster
    {
        public static string GetFullPath(string rootRelativePath)
        {
            if (HttpRuntime.Cache[rootRelativePath] == null)
            {
                string absolute = HostingEnvironment.MapPath("~" + rootRelativePath);

                DateTime date = File.GetLastWriteTime(absolute);

                string result = $"{rootRelativePath}?v={date.Ticks}";
                HttpRuntime.Cache.Insert(rootRelativePath, result, new CacheDependency(absolute));
            }

            return HttpRuntime.Cache[rootRelativePath] as string;
        }
    }
}