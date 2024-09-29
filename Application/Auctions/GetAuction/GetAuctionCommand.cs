using Domain;
using FluentResults;
using MediatR;
using System.Text.Json.Serialization;

namespace Auctions.Application.Auctions.GetAuction
{
    public record GetAuctionCommand : IRequest<Result<IEnumerable<Auction>>>
    {

    }
}
