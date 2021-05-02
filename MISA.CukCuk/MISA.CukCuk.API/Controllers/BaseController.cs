using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Interface.Services;

namespace MISA.CukCuk.API.Controllers
{
    public class BaseController<MISAEntity> : ControllerBase where MISAEntity : class
    {

        IBaseService<MISAEntity> _baseService;

        public BaseController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseService.GetAll();

            if (entities.Count() > 0)
            {
                return Ok(entities);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var entity = _baseService.GetByID(id);

            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public IActionResult Post(MISAEntity entity)
        {
            var rowAffect = _baseService.Insert(entity);

            if (rowAffect > 0)
            {
                return StatusCode(201,rowAffect);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, MISAEntity entity)
        {
            var rowAffect = _baseService.Update(entity, id);

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
            var rowAffect = _baseService.Delete(id);

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
