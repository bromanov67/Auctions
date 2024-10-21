using Domain;
using FluentResults;
using MediatR;

namespace Auctions.Application.Auctions.GetAuctions
{
    public record GetAuctionsCommand : IRequest<Result<IEnumerable<Auction>>>
    {

    }
}
