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
    public class DealerController : ControllerBase
    {
        private IDealerRepository dealerRepo;

        public DealerController(IDealerRepository dealerRepo)
        {
            this.dealerRepo = dealerRepo;
        }
        // GET: api/Dealer
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Dealer>))]
        public ActionResult<IEnumerable<Dealer>> Get()
        {

            return Ok(dealerRepo.Retrieve().ToList());
        }

        // GET: api/Dealer/5
        [HttpGet("{id}", Name = "GetDealerByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Dealer))]
        public async Task<ActionResult<Dealer>> Get(Guid id)
        {
            try
            {
                var result = await dealerRepo.RetrieveAsync(id);
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

        // POST: api/Dealer
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Dealer))]
        public async Task<ActionResult<Dealer>> Post([FromBody] Dealer dealer)
        {
            try
            {
                dealer.DealerID = Guid.NewGuid();
                await dealerRepo.CreateAsync(dealer);
                return CreatedAtRoute("GetDealerByID",
                    new
                    {
                        id = dealer.DealerID
                    },
                    dealer);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Dealer/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Dealer))]
        public async Task<ActionResult<Dealer>> Put(Guid id, [FromBody] Dealer dealer)
        {
            try
            {
                var result = dealerRepo.Retrieve().FirstOrDefault(x => x.DealerID == id);
                if (result == null)
                {
                    return NotFound();
                }
                await dealerRepo.UpdateAsync(id, dealer);

                return Ok(dealer);

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
                var result = dealerRepo.Retrieve().FirstOrDefault(x => x.DealerID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await dealerRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Dealer/5
        [HttpGet("{page}/{itemsPerPage}", Name = "GetDealerWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Dealer>))]
        public async Task<ActionResult<PaginationResult<Dealer>>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Dealer>();
                result = dealerRepo.RetrieveDealerWithPagination(page, itemsPerPage, filter);
                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
