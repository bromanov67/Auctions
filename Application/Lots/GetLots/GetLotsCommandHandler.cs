using Domain;
using FluentResults;
using MediatR;
using System;

namespace Auctions.Application.Auctions.GetAuction
{
    public class GetLotsCommandHandler : IRequestHandler<GetLotsCommand, Result<IEnumerable<Auction>>>
    {
        private readonly IAuctionRepository _auctionRepository;

        public GetLotsCommandHandler(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public async Task<Result<IEnumerable<Auction>>> Handle(GetLotsCommand command, CancellationToken cancellationToken)
        {
            var allAuctions = await _auctionRepository.GetAllAsync(cancellationToken);

            return Result.Ok(allAuctions); // Return all auctions
        }
    }
}
