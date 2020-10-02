using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 控制台日志格式统一管理 
    /// 避免每个微服务定义自己的格式，造成日志格式不统一;
    /// 同时为了后续日志的分析提供基础
    /// 参考:https://github.com/NLog/NLog/wiki/Getting-started-with-.NET-Core-2---Console-application
    /// </summary>
    public static class LoggingConsoleServiceCollectionExtensions
    {
        public static IServiceCollection AddConsoleLogging(this IServiceCollection services, IConfiguration config)
        {
            services.AddLogging(loggingBuilder =>
            {
                // configure Logging with NLog
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                loggingBuilder.AddNLog(config);
            });
            return services;
        }
    }
}
