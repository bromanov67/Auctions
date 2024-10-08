using Auctions.Application.Auctions.ChangeAuction;
using Auctions.Application.Auctions.CreateAuction;
using Auctions.Application.Auctions.GetAuction;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Auctions.Controllers
{
    [ApiController]
    [Route("api/auction")]
    public class AuctionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateAuctionCommand> _createAuctionCommandValidator;
        private readonly IValidator<CancelAuctionCommand> _cancelAuctionCommandValidator;
        private readonly IValidator<GetAuctionsCommand> _getAuctionCommandValidator;


        public AuctionController(IMediator mediator,
            IValidator<CreateAuctionCommand> createValidator,
            IValidator<CancelAuctionCommand> cancelValidator,
            IValidator<GetAuctionsCommand> getAuctionCommandValidator)
        {
            _mediator = mediator;
            _createAuctionCommandValidator = createValidator;
            _cancelAuctionCommandValidator = cancelValidator;
            _getAuctionCommandValidator = getAuctionCommandValidator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuctionAsync(CreateAuctionCommand command, CancellationToken cancellationToken)
        {
            var validateResult = await _createAuctionCommandValidator.ValidateAsync(command, cancellationToken);
            if (!validateResult.IsValid)
                return BadRequest(new { errors = validateResult.Errors.Select(x => x.ErrorMessage) });

            try
            {
                var auction = await _mediator.Send(command, cancellationToken);
                return Ok(auction);
            }
            catch (Exception ex)
            {
                return BadRequest(new { errors = ex.ToString() });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> CancelAuctionAsync(Guid auctionId, CancellationToken cancellationToken)
        {
            var command = new CancelAuctionCommand { AuctionId = auctionId };
            var validateResult = await _cancelAuctionCommandValidator.ValidateAsync(command, cancellationToken);
            if (!validateResult.IsValid)
                return BadRequest(new { errors = validateResult.Errors.Select(x => x.ErrorMessage) });

            try
            {
                await _mediator.Send(command, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { errors = ex.ToString() });
            }
        }
        [HttpPut]
        public async Task<IActionResult> ChangeAuction(Guid id, ChangeAuctionCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(new ChangeAuctionCommand(id, command.Name, command.DateStart, command.DateEnd), cancellationToken);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAuctionsAsync(CancellationToken cancellationToken)
        {
            var command = new GetAuctionsCommand();
            var validateResult = await _getAuctionCommandValidator.ValidateAsync(command, cancellationToken);
            if (!validateResult.IsValid)
                return BadRequest(new { errors = validateResult.Errors.Select(x => x.ErrorMessage) });

            var result = await _mediator.Send(command, cancellationToken);
            if (result.IsFailed)
            {
                return NotFound(result.Errors);
            }

            return Ok(result);
        }

    }
}
