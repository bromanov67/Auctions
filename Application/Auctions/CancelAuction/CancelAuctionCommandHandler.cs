using Auctions.Controllers;
using FluentResults;
using MediatR;

namespace Auctions.Application.Auctions.CancelAuction
{
    public class CancelAuctionCommandHandler : IRequestHandler<CancelAuctionCommand, Result>
    {
        private readonly IAuctionRepository _auctionRepository;

        public CancelAuctionCommandHandler(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public async Task<Result> Handle(CancelAuctionCommand command, CancellationToken cancellationToken)
        {
  
            // Отмена аукциона
            await _auctionRepository.CancelAsync(command.AuctionId);

            return Result.Ok();
        }
    }

}
