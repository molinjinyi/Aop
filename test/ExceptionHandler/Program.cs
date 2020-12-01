using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace ExceptionHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var services = new ServiceCollection();
            services.AddSingleton<IExceptionHandler<DaoException>, DaoExceptionHandler>();
            services.AddSingleton<IExceptionHandler<ServiceException>, ServiceExceptionHandler>();
            services.AddSingleton<IExceptionHandler<BusinessLogicException>, BusinessLogicExceptionHandler>();
            services.AddSingleton<IExceptionHandler<ServerException>, ServerExceptionHandler>();
            var provider = services.BuildServiceProvider();

            try
            {
                throw new DaoException();
            }
            catch (Exception ex)
            {
                //var exceptionHandlers =provider.GetRequiredService(typeof(IExceptionHandler<>));
                var exceptionHandlerInterfaceType = typeof(IExceptionHandler<>).MakeGenericType();
                var enumerableExceptionHandlerInterfaceType = typeof(IEnumerable<>).MakeGenericType(exceptionHandlerInterfaceType);
                var handleMethodInfo = exceptionHandlerInterfaceType.GetMethod(nameof(IExceptionHandler<Exception>.Handle));
                //foreach (var  exceptionHandler in exceptionHandlers)
                //{
                //    exceptionHandler
                //}
                Console.WriteLine(ex.Message);
            }


        }
    }
}
