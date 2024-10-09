using FluentResults;
using MediatR;
using System.Text.Json.Serialization;

namespace Auctions.Application.Auctions.CreateAuction
{
    public record CreateLotCommand :IRequest<Result<Guid>>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("auctionId")]
        public Guid AuctionId { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

    }
}
