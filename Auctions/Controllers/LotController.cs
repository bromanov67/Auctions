using Auctions.Application.Auctions.ChangeAuction;
using Auctions.Application.Auctions.CreateAuction;
using Auctions.Application.Auctions.GetAuction;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auctions.Controllers
{
    [ApiController]
    [Route("api/auction/lots")]
    public class LotController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateLotCommand> _createLotCommandValidator;
        private readonly IValidator<CancelLotCommand> _cancelLotCommandValidator;
        private readonly IValidator<GetLotsCommand> _getLotsCommandValidator;
        private readonly IValidator<ChangeLotCommand> _changeLotCommandValidator;



        public LotController(IMediator mediator,
            IValidator<CreateLotCommand> createValidator,
            IValidator<CancelLotCommand> cancelValidator,
            IValidator<GetLotsCommand> getValidator,
            IValidator<ChangeLotCommand> changeValidator)
        {
            _mediator = mediator;
            _createLotCommandValidator = createValidator;
            _cancelLotCommandValidator = cancelValidator;
            _getLotsCommandValidator = getValidator;
            _changeLotCommandValidator = changeValidator;
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
        public async Task<IActionResult> ChangeLotAsync()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetLotsAsync(int LotId)
        {
            return Ok();
        }
    }
}
