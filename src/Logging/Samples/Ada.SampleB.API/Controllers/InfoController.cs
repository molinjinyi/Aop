using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ada.SampleB.API.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ada.SampleB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IStringLocalizer<InfoController> _localizer;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        private readonly CustomerService _customerService;

        public InfoController(IStringLocalizer<InfoController> localizer,
                   IStringLocalizer<SharedResource> sharedLocalizer,CustomerService customerService)
        {
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;
            _customerService = customerService;
        }
        // GET: api/<InfoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
          var  customer=  _customerService.GetCustomer();
            var customer1 = _customerService.GetCustomer();
            return new string[] { "value1", "value2", _localizer["Hello!"], _sharedLocalizer["Hello!"], customer.Name, customer.GetHashCode().ToString(), customer1.GetHashCode().ToString() };
        }

        
    }
}
