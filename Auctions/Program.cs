using Auctions.Application.Auctions;
using Auctions.Application.Auctions.CancelAuction;
using Auctions.Application.Auctions.ChangeAuction;
using Auctions.Application.Auctions.CreateAuction;
using Auctions.Application.Auctions.GetAuctions;
using Auctions.Application.Lots;
using Auctions.Application.User.CreateUser;
using Auctions.Application.Users;
using Auctions.Database;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

// ����������� ���� �����������
builder.Services.AddValidatorsFromAssemblyContaining<CreateAuctionCommandValidator>();

builder.Services.AddValidatorsFromAssemblyContaining<GetAuctionsCommandValidator>();

builder.Services.AddValidatorsFromAssemblyContaining<ChangeAuctionCommandValidator>();

builder.Services.AddValidatorsFromAssemblyContaining<CancelAuctionCommandValidator>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();



builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ILotRepository, LotRepository>();

var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ���������� DbContext
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
