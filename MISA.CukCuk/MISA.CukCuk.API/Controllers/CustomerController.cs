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
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomerController(ICustomerService customerService) : base()
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = _customerService.GetAll();

            if(customers.Count() > 0)
            {
                return Ok(customers);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var customers = _customerService.GetByID(id);

            if (customers != null)
            {
                return Ok(customers);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            var rowsAffect = _customerService.Insert(customer);

            if(rowsAffect > 0)
            {
                return StatusCode(201, rowsAffect);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Customer customer)
        {
            var rowsAffect = _customerService.Update(customer);

            if (rowsAffect > 0)
            {
                return StatusCode(200, rowsAffect);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var rowsAffect = _customerService.Delete(id);

            if (rowsAffect > 0)
            {
                return StatusCode(200, rowsAffect);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("paging")]
        public IActionResult Paging(int pageIndex, int pageSize, string fullName, Guid? groupId)
        {
            var customers = _customerService.GetOfPage(pageIndex, pageSize, fullName, groupId);
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
