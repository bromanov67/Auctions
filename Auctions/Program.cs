using Auctions.Application.Auctions;
using Auctions.Application.Auctions.CancelAuction;
using Auctions.Application.Auctions.ChangeAuction;
using Auctions.Application.Auctions.CreateAuction;
using Auctions.Application.Auctions.GetAuctions;
using Auctions.Application.Lots;
using Auctions.Application.Lots.CancelLot;
using Auctions.Application.Lots.ChangelLot;
using Auctions.Application.Lots.CreateLot;
using Auctions.Application.Lots.GetLots;
using Auctions.Application.Lots.GetLotsByAuctionId;
using Auctions.Application.User.CreateUser;
using Auctions.Application.Users;
using Auctions.Database;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

// Регистрация всех валидаторов
builder.Services.AddValidatorsFromAssemblyContaining<CreateAuctionCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetAuctionsCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ChangeAuctionCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CancelAuctionCommandValidator>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateLotCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ChangeLotCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CancelLotCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetLotsCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetLotsByAuctionIdCommandValidator>();




builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ILotRepository, LotRepository>();

var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Добавление DbContext
builder.Services.AddDbContext<ApplicationDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
