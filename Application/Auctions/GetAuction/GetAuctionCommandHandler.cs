/*using Domain;
using FluentResults;
using MediatR;

namespace Auctions.Application.Auctions.CreateAuction
{
    public class CancelAuctionCommandHandler : IRequestHandler<CreateActionCommand, Result>
    {
        public Task<Result> Handle(CreateActionCommand command, CancellationToken cancellationToken)
        {
            var auction = new Auction(command.Name, 0, command.DateStart, command.DateEnd);

            return Task.FromResult(Result.Ok());
        }
    }
}
 */