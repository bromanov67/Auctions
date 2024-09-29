using Auctions.Application.Users;
using FluentResults;
using MediatR;


namespace Auctions.Application.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {

            var user = new Domain.User(command.Name, command.Email);
            await _userRepository.CreateAsync(user);
            return Result.Ok();

        }
    }
}
