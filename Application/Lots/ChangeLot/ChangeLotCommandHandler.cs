using Auctions.Application.Lots;
using Auctions.Application.Lots.ChagneLot;
using MediatR;

namespace Auctions.Application.Lots.ChangeLot
{
    public class ChangeLotHandler : IRequestHandler<ChangeLotCommand, Unit>
    {
        private readonly ILotRepository _lotRepository;

        public ChangeLotHandler(ILotRepository lotRepository)
        {
            _lotRepository = lotRepository;
        }

        public async Task<Unit> Handle(ChangeLotCommand command, CancellationToken cancellationToken)
        {
            // Обновляем аукцион по id
            await _lotRepository.ChangeAsync(command.lotId, command.LotName, command.Descriprtion, 
                command.DateStart, command.DateStart,command.BetStep, command.MinPrice, command.RansomPrice, cancellationToken);
                
            return Unit.Value;
        }
    }

}
