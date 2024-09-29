using Auctions.Application.Auctions;
using Auctions.Application.Auctions.CreateAuction;
using Auctions.Application.Auctions.GetAuction;
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

builder.Services.AddValidatorsFromAssemblyContaining<GetAuctionCommandValidator>();

builder.Services.AddValidatorsFromAssemblyContaining<CancelAuctionCommandValidator>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();


builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();


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
