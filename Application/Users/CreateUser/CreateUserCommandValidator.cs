using FluentValidation;
using Auctions.Application.User.CreateUser;

namespace Auctions.Application.User.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator() 
        {
            RuleFor(n => n.Name).NotEmpty().WithMessage("Пустое имя");

        }
    }
}
