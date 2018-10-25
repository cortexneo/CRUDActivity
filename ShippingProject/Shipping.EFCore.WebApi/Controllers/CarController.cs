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
    public class CarController : ControllerBase
    {
        private ICarRepository carRepo;

        public CarController(ICarRepository carRepo)
        {
            this.carRepo = carRepo;
        }
        // GET: api/Car
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Car>))]
        public ActionResult<IEnumerable<Car>> Get()
        {

            return Ok(carRepo.Retrieve().ToList());
        }

        // GET: api/Car/5
        [HttpGet("{id}", Name = "GetCarByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Car))]
        public async Task<ActionResult<Car>> Get(Guid id)
        {
            try
            {
                var result = await carRepo.RetrieveAsync(id);
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

        // POST: api/Car
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Car))]
        public async Task<ActionResult<Car>> Post([FromBody] Car car)
        {
            try
            {
                car.CarID = Guid.NewGuid();
                await carRepo.CreateAsync(car);
                return CreatedAtRoute("GetCarByID",
                    new
                    {
                        id = car.CarID
                    },
                    car);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Car/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Car))]
        public async Task<ActionResult<Car>> Put(Guid id, [FromBody] Car car)
        {
            try
            {
                var result = carRepo.Retrieve().FirstOrDefault(x => x.CarID == id);
                if (result == null)
                {
                    return NotFound();
                }
                await carRepo.UpdateAsync(id, car);

                return Ok(car);

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
                var result = carRepo.Retrieve().FirstOrDefault(x => x.CarID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await carRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Car/5
        [HttpGet("{page}/{itemsPerPage}", Name = "GetCarWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Car>))]
        public async Task<ActionResult<PaginationResult<Car>>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Car>();
                result = carRepo.RetrieveCarWithPagination(page, itemsPerPage, filter);
                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
