using MediatR;

namespace Auctions.Application.Auctions.ChangeAuction
{
    public class ChangeAuctionHandler : IRequestHandler<ChangeAuctionCommand, Unit>
    {
        private readonly IAuctionRepository _auctionRepository;

        public ChangeAuctionHandler(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public async Task<Unit> Handle(ChangeAuctionCommand command, CancellationToken cancellationToken)
        {
            // Обновляем аукцион по id
            await _auctionRepository.ChangeAsync(command.AuctionId, command.Name, command.DateStart, command.DateEnd, cancellationToken);

            return Unit.Value;
        }
    }

}