using FluentValidation;

namespace Auctions.Application.Auctions.CreateAuction
{
    public class CreateLotCommandValidator : AbstractValidator<CreateLotCommand>
    {
        public CreateLotCommandValidator()
        {
            RuleFor(n => n.Name).NotEmpty().WithMessage("Пустое имя");

            /*RuleFor(x => x.DateStart).NotEmpty().WithMessage("Пустая дата начала");
            RuleFor(x => x.DateEnd).NotEmpty().WithMessage("Пустая дата окончания");*/
            /*RuleFor(x => x).Must(x => x.DateEnd == default(DateTime) ||
            x.DateStart == default(DateTime) || x.DateEnd > x.DateStart)
                    .WithMessage("Дата начала не может быть больше даты окончания");*/
        }
    }
}
    