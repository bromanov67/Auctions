using Auctions.Application.User.CreateUser;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Users.Controllers
{
    [ApiController]
    [Route("api/users")]
    
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateUserCommand> _createUserCommandValidator;


        public UserController(IMediator mediator, IValidator<CreateUserCommand> createValidator)
        {
            _mediator = mediator;
            _createUserCommandValidator = createValidator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var validateResult = await _createUserCommandValidator.ValidateAsync(command, cancellationToken);
            if (!validateResult.IsValid)
                return BadRequest(new { errors = validateResult.Errors.Select(x => x.ErrorMessage) });

            try
            {
                var user = await _mediator.Send(command, cancellationToken);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { errors = ex.ToString() });
            }
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
