using Auctions.Controllers;
using FluentResults;
using MediatR;

namespace Auctions.Application.Auctions.CancelAuction
{
    public class CancelLotCommandHandler : IRequestHandler<CancelLotCommand, Result>
    {
        private readonly IAuctionRepository _auctionRepository;

        public CancelLotCommandHandler(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }


        public async Task<Result> Handle(CancelLotCommand command, CancellationToken cancellationToken)
        {

            try
            {
                // Отмена аукциона
                await _auctionRepository.CancelAsync(command.AuctionId, cancellationToken);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }

}
