using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace Auctions.Application.Lots.ChagneLot
{
    public record ChangeLotCommand
        (int lotId, string LotName, string Descriprtion, decimal MinPrice,
         decimal BetStep, decimal? RansomPrice, DateTime DateStart, DateTime DateEnd) : IRequest<Unit>;
}
