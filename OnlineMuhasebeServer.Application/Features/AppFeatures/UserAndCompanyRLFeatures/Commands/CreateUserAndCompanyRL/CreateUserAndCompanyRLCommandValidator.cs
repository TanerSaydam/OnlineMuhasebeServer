using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.CreateUserAndCompanyRL;

public sealed class CreateUserAndCompanyRLCommandValidator : AbstractValidator<CreateUserAndCompanyRLCommand>
{
    public CreateUserAndCompanyRLCommandValidator()
    {
        RuleFor(p => p.AppUserId).NotEmpty().WithMessage("Kullanıcı seçilmelidir!");
        RuleFor(p => p.AppUserId).NotNull().WithMessage("Kullanıcı seçilmelidir!");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket seçilmelidir!");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket seçilmelidir!");
    }
}
