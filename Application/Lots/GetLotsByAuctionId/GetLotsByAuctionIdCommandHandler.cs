using Domain;
using FluentResults;
using MediatR;

namespace Auctions.Application.Lots.GetLotsByAuctionId
{
    public class GetLotsByAuctionIdCommandHandler : IRequestHandler<GetLotsByAuctionIdCommand, Result<IEnumerable<Lot>>>
    {
        private readonly ILotRepository _lotRepository;

        public GetLotsByAuctionIdCommandHandler(ILotRepository lotRepository)
        {
            _lotRepository = lotRepository;
        }

        public async Task<Result<IEnumerable<Lot>>> Handle(GetLotsByAuctionIdCommand command, CancellationToken cancellationToken)
        {
            var allLots = await _lotRepository.GetAllByAuctionIdAsync(command.AuctionId, cancellationToken);

            return Result.Ok(allLots); // Return all auctions
        }
    }
}
