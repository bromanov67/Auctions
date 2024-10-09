using FluentValidation;

namespace Auctions.Application.Auctions.GetAuction
{
    public class GetLotsCommandValidator : AbstractValidator<GetLotsCommand>
    {
        public GetLotsCommandValidator()
        {
            /*RuleFor(x => x.AuctionId).GreaterThan(0).WithMessage("Invalid Auction Id.");*/
            /*RuleFor(x => x.)*/
        }
    }
}
