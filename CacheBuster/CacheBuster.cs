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
            string returnValue;
            if (HttpRuntime.Cache[rootRelativePath] == null)
            {
                string absolute = rootRelativePath.StartsWith("~")
                    ? HostingEnvironment.MapPath(rootRelativePath)
                    : HostingEnvironment.MapPath($"~{rootRelativePath}");

                if (File.Exists(absolute))
                {
                    DateTime date = File.GetLastWriteTime(absolute ?? "");

                    string result = $"{rootRelativePath}?v={date.Ticks}";
                    HttpRuntime.Cache.Insert(rootRelativePath, result, new CacheDependency(absolute));
                    returnValue = HttpRuntime.Cache[rootRelativePath] as string;
                }
                else
                {
                    returnValue = rootRelativePath;
                }
            }
            else
            {
                returnValue = HttpRuntime.Cache[rootRelativePath] as string;
            }

            return returnValue;
        }
    }
}