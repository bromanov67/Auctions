using Domain;
using FluentResults;
using MediatR;

namespace Auctions.Application.Auctions.CreateAuction
{
    
    public class CreateAuctionCommandHandler : IRequestHandler<CreateAuctionCommand, Result>
    {
        private readonly IAuctionRepository _auctionRepository;

        public CreateAuctionCommandHandler(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }
        public async Task<Result> Handle(CreateAuctionCommand command, CancellationToken cancellationToken)
        {

            var auction = new Auction(command.Name, command.UserId, command.DateStart, command.DateEnd);
            await _auctionRepository.CreateAsync(auction);
            return Result.Ok();

        }
    }
}
 