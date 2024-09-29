using Auctions.Application.Auctions;
using Auctions.Application.Auctions.CreateAuction;
using Auctions.Application.User.CreateUser;
using Auctions.Application.Users;
using Auctions.Database;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

// Регистрация всех валидаторов
builder.Services.AddValidatorsFromAssembly(typeof(CreateAuctionCommandValidator).Assembly);
builder.Services.AddScoped<IValidator<CreateAuctionCommand>, CreateAuctionCommandValidator>();
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddValidatorsFromAssemblyContaining<CancelAuctionCommandValidator>();

builder.Services.AddValidatorsFromAssembly(typeof(CreateUserCommandValidator).Assembly);
builder.Services.AddScoped<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Добавление DbContext
builder.Services.AddDbContext<AuctionsDbContext>();


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
