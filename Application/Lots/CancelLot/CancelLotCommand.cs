﻿using FluentResults;
using MediatR;
using System.Text.Json.Serialization;

namespace Auctions.Controllers
{
    public record CancelLotCommand : IRequest<Result>
    {
        [JsonPropertyName("auctionId")]
        public Guid AuctionId { get; set; }


    }
}