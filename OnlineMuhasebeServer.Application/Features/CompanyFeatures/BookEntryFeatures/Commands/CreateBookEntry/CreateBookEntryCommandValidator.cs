using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.CreateBookEntry;

public sealed class CreateBookEntryCommandValidator : AbstractValidator<CreateBookEntryCommand>
{
    public CreateBookEntryCommandValidator()
    {
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz!");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket bilgisi boş olamaz!");
        RuleFor(p => p.Date).NotEmpty().WithMessage("Tarih bilgisi boş olamaz!");
        RuleFor(p => p.Date).NotNull().WithMessage("Tarih bilgisi boş olamaz!");
        RuleFor(p => p.Description).NotEmpty().WithMessage("Açıklama bilgisi boş olamaz!");
        RuleFor(p => p.Description).NotNull().WithMessage("Açıklama bilgisi boş olamaz!");
        RuleFor(p => p.Type).NotEmpty().WithMessage("Tip bilgisi boş olamaz!");
        RuleFor(p => p.Type).NotNull().WithMessage("Tip bilgisi boş olamaz!");
    }
}
