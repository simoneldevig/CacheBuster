﻿using System;
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
                try
                {
                    string absolute = rootRelativePath.StartsWith("~")
                        ? HostingEnvironment.MapPath(rootRelativePath)
                        : HostingEnvironment.MapPath($"~{rootRelativePath}");

                    DateTime date = File.GetLastWriteTime(absolute);

                    string result = $"{rootRelativePath}?v={date.Ticks}";
                    HttpRuntime.Cache.Insert(rootRelativePath, result, new CacheDependency(absolute));

                    return HttpRuntime.Cache[rootRelativePath] as string;
                }
                catch
                {
                    // ignored
                }
            }
            return rootRelativePath;
        }
    }
}