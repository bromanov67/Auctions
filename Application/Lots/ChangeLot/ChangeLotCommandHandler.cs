using Auctions.Application.Lots;
using MediatR;

namespace Auctions.Application.Auctions.ChangeAuction
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
          /*  // Обновляем аукцион по id
            await _lotRepository.ChangeAsync(command.LotId, command.Name, command.DateStart, command.DateEnd, cancellationToken);
*/
            return Unit.Value;
        }
    }

}
