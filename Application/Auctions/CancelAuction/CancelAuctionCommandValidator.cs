using Auctions.Controllers;
using FluentValidation;

namespace Auctions.Application.Auctions.CancelAuction
{
    public class CancelAuctionCommandValidator : AbstractValidator<CancelAuctionCommand>
    {
        private readonly IAuctionRepository _auctionRepository;

        private async Task<bool> AuctionExists(int auctionId, CancellationToken cancellationToken)
        {
            var auction = await _auctionRepository.GetByIdAsync(auctionId);
            return auction != null;
        }

        public CancelAuctionCommandValidator(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;

            RuleFor(x => x.AuctionId)
                .NotEmpty()
                .MustAsync(AuctionExists)
                .WithMessage("Аукцион не найден.");

            RuleFor(x => x)
                .MustAsync(AuctionNotCanceled)
                .WithMessage("Аукцион уже был отменен.");
        }


        private async Task<bool> AuctionNotCanceled(CancelAuctionCommand command, CancellationToken cancellationToken)
        {
            var auction = await _auctionRepository.GetByIdAsync(command.AuctionId);
            return !auction.IsCanceled;
        }
    }
}
