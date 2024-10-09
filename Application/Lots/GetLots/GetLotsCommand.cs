using Domain;
using FluentResults;
using MediatR;
using System.Text.Json.Serialization;

namespace Auctions.Application.Auctions.GetAuction
{
    public record GetLotsCommand : IRequest<Result<IEnumerable<Auction>>>
    {

    }
}
