using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 参考：https://github.com/NLog/NLog/wiki/Getting-started-with-ASP.NET-Core-3
    /// </summary>
    public static class LoggingWebServiceCollectionExtensions
    {
        public static IServiceCollection AddWebLogging(this IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
            {
               
            });
            return services;
        }
    }
}
