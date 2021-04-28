using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interface.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.API.Controllers
{
    [Route("api/v1/customer-group")]
    [ApiController]
    public class CustomerGroupController : Controller
    {
        ICustomerGroupService _customerGroupService;


        public CustomerGroupController(ICustomerGroupService customerGroupService)
        {
            _customerGroupService = customerGroupService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customerGroups = _customerGroupService.GetAll();

            if(customerGroups.Count() > 0)
            {
                return Ok(customerGroups);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var customerGroup = _customerGroupService.GetByID(id);

            if (customerGroup != null)
            {
                return Ok(customerGroup);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public IActionResult Post(CustomerGroup customerGroup)
        {
            var rowAffect = _customerGroupService.Insert(customerGroup);

            if (rowAffect > 0)
            {
                return Ok(rowAffect);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(CustomerGroup customerGroup)
        {
            var rowAffect = _customerGroupService.Update(customerGroup);

            if (rowAffect > 0)
            {
                return Ok(rowAffect);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var rowAffect = _customerGroupService.Delete(id);

            if (rowAffect > 0)
            {
                return Ok(rowAffect);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
