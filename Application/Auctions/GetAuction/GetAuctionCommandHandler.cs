using Domain;
using FluentResults;
using MediatR;
using System;

namespace Auctions.Application.Auctions.GetAuction
{
    public class GetAuctionCommandHandler : IRequestHandler<GetAuctionCommand, Result<IEnumerable<Auction>>>
    {
        private readonly IAuctionRepository _auctionRepository;

        public GetAuctionCommandHandler(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public async Task<Result<IEnumerable<Auction>>> Handle(GetAuctionCommand command, CancellationToken cancellationToken)
        {
            var allAuctions = await _auctionRepository.GetAllAsync();

            if (allAuctions == null || !allAuctions.Any())
            {
                return Result.Fail("Аукционы не найдены");
            }

            return Result.Ok(allAuctions); // Return all auctions
        }
    }
}
