using NLog.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.Hosting
{
    public static class HostingHostBuilderExtensions
    {
        /// <summary>
        /// https://github.com/NLog/NLog/wiki/Getting-started-with-ASP.NET-Core-3
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <returns></returns>
        public static IHostBuilder UseWebNLog(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseNLog();
            return hostBuilder;
        }
    }
}
