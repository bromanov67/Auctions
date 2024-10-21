using FluentValidation;

namespace Auctions.Application.Lots.GetLotsByAuctionId
{
    public class GetLotsByAuctionIdCommandValidator : AbstractValidator<GetLotsByAuctionIdCommand>
    {
        public GetLotsByAuctionIdCommandValidator()
        {
            /*RuleFor(x => x.AuctionId).GreaterThan(0).WithMessage("Invalid Auction Id.");*/
            /*RuleFor(x => x.)*/
        }
    }
}
