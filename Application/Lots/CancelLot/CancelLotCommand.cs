using FluentResults;
using MediatR;
using System.Text.Json.Serialization;

namespace Auctions.Controllers
{
    public record CancelLotCommand : IRequest<Result>
    {
        [JsonPropertyName("lotId")]
        public int LotId { get; set; }
    }
}