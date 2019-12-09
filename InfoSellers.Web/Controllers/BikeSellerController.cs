using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoSellers.Model.Entities;
using InfoSellers.Model.Services;
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
        public async Task<ActionResult<BikeSeller>> GetBikeSeller(int id)
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
        public async Task<IActionResult> PutBikeSeller(int id, BikeSeller bikeSeller)
        {
            if (id != bikeSeller.Id || bikeSeller.Role.Id != bikeSeller.RoleId)
            {
                return BadRequest();
            }
            var res = await _bikeSellerBusinessService.Update(id, bikeSeller);

            return NoContent();
        }

        // POST: api/BikeSeller
        [HttpPost]
        public async Task<ActionResult<BikeSeller>> PostBikeSeller(BikeSeller bikeSeller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _bikeSellerBusinessService.Add(bikeSeller);
            return CreatedAtAction("GetBikeSellers", new { id = bikeSeller.Id }, bikeSeller);
        }

        // DELETE: api/BikeSeller/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBikeSeller(int id)
        {
            var res = await _bikeSellerBusinessService.Delete(id);
            return NoContent();
        }
    }
}
