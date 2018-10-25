using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.EFCore.Domain;
using Shipping.EFCore.Domain.Models;

namespace Shipping.EFCore.WebApi.Controllers
{
    [EnableCors("OnlineStoreAngular6")]
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsibilityController : ControllerBase
    {
        private IResponsibilityRepository responsibilityRepo;

        public ResponsibilityController(IResponsibilityRepository responsibilityRepo)
        {
            this.responsibilityRepo = responsibilityRepo;
        }
        // GET: api/Responsibility
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Responsibility>))]
        public ActionResult<IEnumerable<Responsibility>> Get()
        {

            return Ok(responsibilityRepo.Retrieve().ToList());
        }

        // GET: api/Responsibility/5
        [HttpGet("{id}", Name = "GetResponsibilityByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Responsibility))]
        public async Task<ActionResult<Responsibility>> Get(Guid id)
        {
            try
            {
                var result = await responsibilityRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Responsibility
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Responsibility))]
        public async Task<ActionResult<Responsibility>> Post([FromBody] Responsibility responsibility)
        {
            try
            {
                responsibility.ResponsibilityID = Guid.NewGuid();
                await responsibilityRepo.CreateAsync(responsibility);
                return CreatedAtRoute("GetResponsibilityByID",
                    new
                    {
                        id = responsibility.ResponsibilityID
                    },
                    responsibility);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Responsibility/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Responsibility))]
        public async Task<ActionResult<Responsibility>> Put(Guid id, [FromBody] Responsibility responsibility)
        {
            try
            {
                var result = responsibilityRepo.Retrieve().FirstOrDefault(x => x.ResponsibilityID == id);
                if (result == null)
                {
                    return NotFound();
                }
                await responsibilityRepo.UpdateAsync(id, responsibility);

                return Ok(responsibility);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = responsibilityRepo.Retrieve().FirstOrDefault(x => x.ResponsibilityID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await responsibilityRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Responsibility/5
        [HttpGet("{page}/{itemsPerPage}", Name = "GetResponsibilityWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Responsibility>))]
        public async Task<ActionResult<PaginationResult<Responsibility>>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Responsibility>();
                result = responsibilityRepo.RetrieveResponsibilityWithPagination(page, itemsPerPage, filter);
                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
