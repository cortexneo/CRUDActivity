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
    public class LaptopController : ControllerBase
    {
        private ILaptopRepository laptopRepo;

        public LaptopController(ILaptopRepository laptopRepo)
        {
            this.laptopRepo = laptopRepo;
        }
        // GET: api/Laptop
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Laptop>))]
        public ActionResult<IEnumerable<Laptop>> Get()
        {

            return Ok(laptopRepo.Retrieve().ToList());
        }

        // GET: api/Laptop/5
        [HttpGet("{id}", Name = "GetLaptopByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Laptop))]
        public async Task<ActionResult<Laptop>> Get(Guid id)
        {
            try
            {
                var result = await laptopRepo.RetrieveAsync(id);
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

        // POST: api/Laptop
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Laptop))]
        public async Task<ActionResult<Laptop>> Post([FromBody] Laptop laptop)
        {
            try
            {
                laptop.LaptopID = Guid.NewGuid();
                await laptopRepo.CreateAsync(laptop);
                return CreatedAtRoute("GetLaptopByID",
                    new
                    {
                        id = laptop.LaptopID
                    },
                    laptop);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Laptop/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Laptop))]
        public async Task<ActionResult<Laptop>> Put(Guid id, [FromBody] Laptop laptop)
        {
            try
            {
                var result = laptopRepo.Retrieve().FirstOrDefault(x => x.LaptopID == id);
                if (result == null)
                {
                    return NotFound();
                }
                await laptopRepo.UpdateAsync(id, laptop);

                return Ok(laptop);

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
                var result = laptopRepo.Retrieve().FirstOrDefault(x => x.LaptopID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await laptopRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Person/5
        [HttpGet("{page}/{itemsPerPage}", Name = "GetLaptopWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Laptop>))]
        public async Task<ActionResult<PaginationResult<Laptop>>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Laptop>();
                result = laptopRepo.RetrieveLaptopWithPagination(page, itemsPerPage, filter);
                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
