using Auctions.Controllers;
using FluentValidation;

namespace Auctions.Application.Auctions.CancelAuction
{
    public class CancelAuctionCommandValidator : AbstractValidator<CancelAuctionCommand>
    {
        public CancelAuctionCommandValidator()
        {

        }
    }
}
