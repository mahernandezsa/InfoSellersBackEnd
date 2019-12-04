using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoSellers.Model.Entities;
using InfoSellers.Model.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfoSellers.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeSellerController : ControllerBase
    {
        private readonly IBusinessService<BikeSeller,int> _bikeSellerBusinessService;
        
        public BikeSellerController(IBusinessService<BikeSeller, int> _businessService)
        {
            _bikeSellerBusinessService = _businessService;
        }

        // GET: api/BikeSeller
        [HttpGet]
        public ActionResult<IEnumerable<BikeSeller>> GetBikeSellers()
        {
            return _bikeSellerBusinessService.GetAll().ToList();
        }

        // GET: api/BikeSeller/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BikeSeller>> GetBikeSellers(int id)
        {
            var bikeSeller = await _bikeSellerBusinessService.GetById(id);

            if (bikeSeller == null)
            {
                return NotFound();
            }

            return bikeSeller;
        }


        // PUT: api/BikeSeller/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBikeSellers(int id, BikeSeller bikeSeller)
        {
            if (id != bikeSeller.Id)
            {
                return BadRequest();
            }
            var res = await _bikeSellerBusinessService.Update(id, bikeSeller);

            return NoContent();
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<BikeSeller>> PostBikeSellers(BikeSeller bikeSeller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _bikeSellerBusinessService.Add(bikeSeller);
            return CreatedAtAction("GetBikeSellers", new { id = bikeSeller.Id }, bikeSeller);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBikeSellers(int id)
        {
            var res = await _bikeSellerBusinessService.Delete(id);
            return NoContent();
        }
    }
}
