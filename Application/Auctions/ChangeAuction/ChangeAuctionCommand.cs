using FluentResults;
using MediatR;
using System.Text.Json.Serialization;

namespace Auctions.Application.Auctions.CreateAuction
{
    public record CreateActionCommand :IRequest<Result>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("dateStart")]
        public DateTime DateStart { get; set; }


        [JsonPropertyName("dateEnd")]
        public DateTime DateEnd { get; set; }

    }
}
