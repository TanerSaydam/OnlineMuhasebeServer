using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.UpdateBookEntry;

public sealed class UpdateBookEntryCommandValidator : AbstractValidator<UpdateBookEntryCommand>
{
    public UpdateBookEntryCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id alanı boş olamaz!");
        RuleFor(p => p.Id).NotNull().WithMessage("Id alanı boş olamaz!");
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
