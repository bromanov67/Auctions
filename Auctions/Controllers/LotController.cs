using Auctions.Application.Lots.ChagneLot;
using Auctions.Application.Lots.CreateLot;
using Auctions.Application.Lots.GetLots;
using Auctions.Application.Lots.GetLotsByAuctionId;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auctions.Controllers
{
    [ApiController]
    [Route("api/auctions/lots")]
    public class LotController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateLotCommand> _createLotCommandValidator;
        private readonly IValidator<CancelLotCommand> _cancelLotCommandValidator;
        private readonly IValidator<GetLotsCommand> _getLotsCommandValidator;
        private readonly IValidator<GetLotsByAuctionIdCommand> _getLotsByAuctionIdCommandValidator;
        private readonly IValidator<ChangeLotCommand> _changeLotCommandValidator;



        public LotController(IMediator mediator,
            IValidator<CreateLotCommand> createValidator,
            IValidator<CancelLotCommand> cancelValidator,
            IValidator<GetLotsCommand> getValidator,
            IValidator<ChangeLotCommand> changeValidator,
            IValidator<GetLotsByAuctionIdCommand> getByAuctionIdValidator)
        {
            _mediator = mediator;
            _createLotCommandValidator = createValidator;
            _cancelLotCommandValidator = cancelValidator;
            _getLotsCommandValidator = getValidator;
            _changeLotCommandValidator = changeValidator;
            _getLotsByAuctionIdCommandValidator = getByAuctionIdValidator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLotAsync(CreateLotCommand command, CancellationToken cancellationToken)
        {
            var validateResult = await _createLotCommandValidator.ValidateAsync(command, cancellationToken);
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
        public async Task<IActionResult> CancelLotAsync()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> ChangeLotAsync(ChangeLotCommand command, CancellationToken cancellationToken)
        {
            var validateResult = await _changeLotCommandValidator.ValidateAsync(command, cancellationToken);
            if (!validateResult.IsValid)
                return BadRequest(new { errors = validateResult.Errors.Select(x => x.ErrorMessage) });
            await _mediator.Send(new ChangeLotCommand(command.lotId, command.LotName,command.Descriprtion, 
                command.MinPrice, command.BetStep, command.RansomPrice, command.DateStart, command.DateEnd), cancellationToken);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetLotsAsync(CancellationToken cancellationToken)
        {
            var command = new GetLotsCommand();
            var validateResult = await _getLotsCommandValidator.ValidateAsync(command, cancellationToken);
            if (!validateResult.IsValid)
                return BadRequest(new { errors = validateResult.Errors.Select(x => x.ErrorMessage) });

            var result = await _mediator.Send(command, cancellationToken);
            if (result.IsFailed)
            {
                return NotFound(result.Errors);
            }

            return Ok(result);
        }

        [HttpPost("byId")]
        public async Task<IActionResult> GetLotsByAuctionIdAsync(GetLotsByAuctionIdCommand command, CancellationToken cancellationToken)
        {
            var validateResult = await _getLotsByAuctionIdCommandValidator.ValidateAsync(command, cancellationToken);
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
