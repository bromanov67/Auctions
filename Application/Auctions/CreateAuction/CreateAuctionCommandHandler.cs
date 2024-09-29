using Domain;
using FluentResults;
using MediatR;

namespace Auctions.Application.Auctions.CreateAuction
{
    
    public class CreateAuctionCommandHandler : IRequestHandler<CreateAuctionCommand, Result<Guid>>
    {
        private readonly IAuctionRepository _auctionRepository;

        public CreateAuctionCommandHandler(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }
        public async Task<Result<Guid>> Handle(CreateAuctionCommand command, CancellationToken cancellationToken)
        {

            var auction = new Auction(command.Name, command.UserId, command.DateStart, command.DateEnd);
            await _auctionRepository.CreateAsync(auction);
            return Result.Ok(auction.Id);

        }
    }
}
 