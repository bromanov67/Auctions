using Auctions.Controllers;
using FluentValidation;

namespace Auctions.Application.Auctions.CancelAuction
{
    public class CancelLotCommandValidator : AbstractValidator<CancelLotCommand>
    {
        public CancelLotCommandValidator()
        {

        }
    }
}
