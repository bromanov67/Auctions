using Auctions.Application.Auctions.CreateAuction;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auctions.Controllers
{
    [ApiController]
    [Route("api/auction")]
    public class AuctionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateAuctionCommand> _createAuctionCommandValidator;
        private readonly IValidator<CancelAuctionCommand> _cancelAuctionCommandValidator;


        public AuctionController(IMediator mediator, IValidator<CreateAuctionCommand> createValidator, IValidator<CancelAuctionCommand> cancelValidator)
        {
            _mediator = mediator;
            _createAuctionCommandValidator = createValidator;
            _cancelAuctionCommandValidator = cancelValidator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuctionAsync(CreateAuctionCommand command, CancellationToken cancellationToken)
        {
            var validateResult = await _createAuctionCommandValidator.ValidateAsync(command, cancellationToken);
            if (!validateResult.IsValid)
                return BadRequest(new { errors = validateResult.Errors.Select(x => x.ErrorMessage) });

            try
            {
                await _mediator.Send(command, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
               return BadRequest(new { errors =  ex.ToString() });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> CancelAuctionAsync([FromQuery] CancelAuctionCommand command, CancellationToken cancellationToken)
        {
            var validateResult = await _cancelAuctionCommandValidator.ValidateAsync(command, cancellationToken);
            if (!validateResult.IsValid)
                return BadRequest(new { errors = validateResult.Errors.Select(x => x.ErrorMessage) });

            await _mediator.Send(command, cancellationToken);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> ChangeAuctionAsync()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAuctionsAsync()
        {

            return Ok();
        }

    }
}
