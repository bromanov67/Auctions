using Auctions.Controllers;
using FluentValidation;

namespace Auctions.Application.Lots.CancelLot
{
    public class CancelLotCommandValidator : AbstractValidator<CancelLotCommand>
    {
        public CancelLotCommandValidator()
        {

        }
    }
}
