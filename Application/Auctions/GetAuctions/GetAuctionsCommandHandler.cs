using Domain;
using FluentResults;
using MediatR;
using System;

namespace Auctions.Application.Auctions.GetAuction
{
    public class GetAuctionsCommandHandler : IRequestHandler<GetAuctionsCommand, Result<IEnumerable<Auction>>>
    {
        private readonly IAuctionRepository _auctionRepository;

        public GetAuctionsCommandHandler(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public async Task<Result<IEnumerable<Auction>>> Handle(GetAuctionsCommand command, CancellationToken cancellationToken)
        {
            var allAuctions = await _auctionRepository.GetAllAsync(cancellationToken);

            return Result.Ok(allAuctions); // Return all auctions
        }
    }
}
