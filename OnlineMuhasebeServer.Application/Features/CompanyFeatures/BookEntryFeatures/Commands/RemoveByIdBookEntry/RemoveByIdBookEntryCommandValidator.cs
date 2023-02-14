using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.RemoveByIdBookEntry;

public sealed class RemoveByIdBookEntryCommandValidator : AbstractValidator<RemoveByIdBookEntryCommand>
{
    public RemoveByIdBookEntryCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id alanı boş olamaz!");
        RuleFor(p => p.Id).NotNull().WithMessage("Id alanı boş olamaz!");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket bilgisi boş olamaz!");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz!");
    }
}
