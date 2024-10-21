using Domain;
using FluentResults;
using MediatR;

namespace Auctions.Application.Lots.GetLots
{
    public class GetLotsCommandHandler : IRequestHandler<GetLotsCommand, Result<IEnumerable<Lot>>>
    {
        private readonly ILotRepository _lotRepository;

        public GetLotsCommandHandler(ILotRepository lotRepository)
        {
            _lotRepository = lotRepository;
        }

        public async Task<Result<IEnumerable<Lot>>> Handle(GetLotsCommand command, CancellationToken cancellationToken)
        {
            var allLots = await _lotRepository.GetAllAsync(cancellationToken);

            return Result.Ok(allLots); // Return all auctions
        }
    }
}
