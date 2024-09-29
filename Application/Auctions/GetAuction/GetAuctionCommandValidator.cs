using FluentValidation;

namespace Auctions.Application.Auctions.GetAuction
{
    public class GetAuctionCommandValidator : AbstractValidator<GetAuctionCommand>
    {
        public GetAuctionCommandValidator()
        {
/*            RuleFor(x => x.AuctionId).GreaterThan(0).WithMessage("Invalid Auction Id.");
*/        }
    }
}
