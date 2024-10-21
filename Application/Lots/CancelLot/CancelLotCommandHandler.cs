using Auctions.Application.Lots;
using Auctions.Controllers;
using FluentResults;
using MediatR;

namespace Auctions.Application.Lots.CancelLot
{
    public class CancelLotCommandHandler : IRequestHandler<CancelLotCommand, Result>
    {
        private readonly ILotRepository _lotRepository;

        public CancelLotCommandHandler(ILotRepository lotRepository)
        {
            _lotRepository = lotRepository;
        }


        public async Task<Result> Handle(CancelLotCommand command, CancellationToken cancellationToken)
        {

            try
            {
                // Отмена аукциона
                await _lotRepository.CancelAsync(command.LotId, cancellationToken);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }

}
