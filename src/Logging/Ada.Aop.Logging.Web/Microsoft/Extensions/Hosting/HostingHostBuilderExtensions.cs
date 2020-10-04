using NLog.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.Hosting
{
    public static class HostingHostBuilderExtensions
    {
        public static IHostBuilder UseNLog(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseNLog();
            return hostBuilder;
        }
    }
}
