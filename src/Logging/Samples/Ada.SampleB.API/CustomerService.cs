using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ada.SampleB.API
{
    public class CustomerService
    {
     
        public IServiceProvider _serviceProvider;

        public CustomerService(IServiceProvider  serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public Customer GetCustomer() {
            using (var scope=_serviceProvider.CreateScope())
            {
              return  scope.ServiceProvider.GetService<Customer>();
            }
        }
        
    }
}
