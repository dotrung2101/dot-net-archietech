using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interface.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.API.Controllers
{
    [Route("api/v1/customer-group")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class CustomerGroupController : BaseController<CustomerGroup>
    {
        ICustomerGroupService _customerGroupService;


        public CustomerGroupController(ICustomerGroupService customerGroupService) : base(customerGroupService)
        {
            _customerGroupService = customerGroupService;
        }

        
    }
}
