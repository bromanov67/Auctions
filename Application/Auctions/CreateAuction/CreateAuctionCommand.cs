using FluentResults;
using MediatR;
using System.Text.Json.Serialization;

namespace Auctions.Application.Auctions.CreateAuction
{
    public record CreateAuctionCommand :IRequest<Result>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;


        [JsonPropertyName("dateStart")]
        public DateTime DateStart { get; set; }


        [JsonPropertyName("dateEnd")]
        public DateTime DateEnd { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

    }
}
