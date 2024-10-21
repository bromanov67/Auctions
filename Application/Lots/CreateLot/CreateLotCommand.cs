using FluentResults;
using MediatR;
using System.Text.Json.Serialization;

namespace Auctions.Application.Lots.CreateLot
{
    public record CreateLotCommand :IRequest<Result<int>>
    {
        [JsonPropertyName("lotName")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("auctionId")]
        public int AuctionId { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("minPrice")]
        public decimal MinPrice { get; set; }

        [JsonPropertyName("betStep")]
        public decimal BetStep { get; set; }

        [JsonPropertyName("ransomPrice")]
        public decimal? RansomPrice { get; set; }

        [JsonPropertyName("images")]
        public string Images { get; set; } = string.Empty;
    }
}
