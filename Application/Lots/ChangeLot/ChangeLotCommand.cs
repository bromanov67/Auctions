﻿using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace Auctions.Application.Auctions.ChangeAuction
{
    public record ChangeLotCommand(Guid AuctionId, string Name, DateTime DateStart, DateTime DateEnd) : IRequest<Unit>;
}