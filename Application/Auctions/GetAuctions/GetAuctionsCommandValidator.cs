using FluentValidation;

namespace Auctions.Application.Auctions.GetAuctions
{
    public class GetAuctionsCommandValidator : AbstractValidator<GetAuctionsCommand>
    {
        public GetAuctionsCommandValidator()
        {
            /*RuleFor(x => x.AuctionId).GreaterThan(0).WithMessage("Invalid Auction Id.");*/
            /*RuleFor(x => x.)*/
        }
    }
}
