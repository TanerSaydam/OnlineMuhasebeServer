using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.RemoveByIdUserAndCompanyRL;

public sealed class RemoveByIdUserAndCompanyRLCommandValidator: AbstractValidator<RemoveByIdUserAndCompanyRLCommand>
{
    public RemoveByIdUserAndCompanyRLCommandValidator()
    {
        RuleFor(p=> p.Id).NotEmpty().WithMessage("Id alanı boş olamaz!");
        RuleFor(p=> p.Id).NotNull().WithMessage("Id alanı boş olamaz!");
    }
}
