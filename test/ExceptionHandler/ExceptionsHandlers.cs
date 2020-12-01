using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandler
{
    public class DaoExceptionHandler : IExceptionHandler<DaoException>
    {
        public Task Handle(DaoException exception)
        {
            throw new NotImplementedException();
        }
    }

    public class ServiceExceptionHandler : IExceptionHandler<ServiceException>
    {
        public Task Handle(ServiceException exception)
        {
            throw new NotImplementedException();
        }
    }


    public class BusinessLogicExceptionHandler : IExceptionHandler<BusinessLogicException>
    {
        public Task Handle(BusinessLogicException exception)
        {
            throw new NotImplementedException();
        }
    }


    public class ServerExceptionHandler : IExceptionHandler<ServerException>
    {
        public Task Handle(ServerException exception)
        {
            throw new NotImplementedException();
        }
    }

    public interface IExceptionHandler<TException> where TException : Exception
    {
        Task Handle(TException exception);
    }
}
