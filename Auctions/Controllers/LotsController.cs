using Microsoft.AspNetCore.Mvc;

namespace Auctions.Controllers
{
    [ApiController]
    [Route("api/auction/lots")]
    public class LotsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateLotAsync()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLotAsync()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLotAsync()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetLotsByAutcionIdAsync([FromQuery]int auctionId)
        {
            return Ok();
        }
    }
}
