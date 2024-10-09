using Microsoft.AspNetCore.Mvc;

namespace Auctions.Controllers
{
    [ApiController]
    [Route("api/auction/lots/bets")]
    public class BetController : ControllerBase
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
    }
}
