using Auctions.Application.Lots;
using Domain;
using FluentResults;
using MediatR;

namespace Auctions.Application.Auctions.CreateAuction
{

    public class CreateLotCommandHandler : IRequestHandler<CreateLotCommand, Result<Guid>>
    {
        private readonly ILotRepository _lotRepository;

        public CreateLotCommandHandler(ILotRepository lotRepository)
        {
            _lotRepository = lotRepository;
        }
        public async Task<Result<Guid>> Handle(CreateLotCommand command, CancellationToken cancellationToken)
        {

            var auction = new Lot(command.Name, command.AuctionId, command.Description);
            await _lotRepository.CreateAsync(auction, cancellationToken);
            return Result.Ok(auction.Id);

        }
    }
}
 