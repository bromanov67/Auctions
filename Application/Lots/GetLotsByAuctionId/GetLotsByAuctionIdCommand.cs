using Domain;
using FluentResults;
using MediatR;
using System.Text.Json.Serialization;

namespace Auctions.Application.Lots.GetLotsByAuctionId
{
    public record GetLotsByAuctionIdCommand : IRequest<Result<IEnumerable<Lot>>>
    {
        [JsonPropertyName("auctionId")]
        public int AuctionId { get; set; }
    }
}
