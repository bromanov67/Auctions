using Auctions.Application.Users;
using FluentResults;
using MediatR;


namespace Auctions.Application.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<Guid>>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result<Guid>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {

            var user = new Domain.User(command.Name, command.Email, command.Id);
            await _userRepository.CreateAsync(user, cancellationToken);
            return Result.Ok(user.Id);

        }
    }
}
