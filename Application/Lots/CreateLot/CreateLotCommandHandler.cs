using Auctions.Application.Auctions;
using Domain;
using FluentResults;
using MediatR;

namespace Auctions.Application.Lots.CreateLot
{

    public class CreateLotCommandHandler : IRequestHandler<CreateLotCommand, Result<int>>
    {
        private readonly ILotRepository _lotRepository;
        private readonly IAuctionRepository _auctionRepository;

        public CreateLotCommandHandler(ILotRepository lotRepository, IAuctionRepository auctionRepository)
        {
            _lotRepository = lotRepository;
            _auctionRepository = auctionRepository;
        }
        public async Task<Result<int>> Handle(CreateLotCommand command, CancellationToken cancellationToken)
        {
            var lot = new Lot(command.Name, command.AuctionId, command.Description, 
                             command.BetStep, command.MinPrice, command.RansomPrice, command.Images);
            await _lotRepository.CreateAsync(lot, cancellationToken);
            return Result.Ok(lot.Id);
        }
    }
}
 