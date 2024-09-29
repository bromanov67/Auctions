﻿using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Auctions.Application.User.CreateUser
{
    public record CreateUserCommand : IRequest<Result>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
       
    }
}