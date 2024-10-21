using Domain;
using FluentResults;
using MediatR;

namespace Auctions.Application.Lots.GetLots
{
    public record GetLotsCommand : IRequest<Result<IEnumerable<Lot>>>
    {

    }
}
