using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interface.Repository;
using MISA.CukCuk.Core.Interface.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.API.Controllers
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomerController : BaseController<Customer>
    {
        ICustomerService _customerService;

        public CustomerController(ICustomerService customerService) : base(customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("paging")]
        public IActionResult Paging(int pageIndex, int pageSize, string fullName, Guid? groupId)
        {
            
            var customers = _customerService.GetOfPage(pageIndex, pageSize, fullName, groupId);

            if(customers == null)
            {
                return NoContent();
            }

            if(customers.Count() > 0)
            {
                return Ok(customers);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
