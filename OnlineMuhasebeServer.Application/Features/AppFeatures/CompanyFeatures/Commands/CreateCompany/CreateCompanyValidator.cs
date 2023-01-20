using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
public sealed class CreateCompanyValidator : AbstractValidator<CreateCompanyCommand>
{
	public CreateCompanyValidator()
	{
		RuleFor(p=> p.DatabaseName).NotEmpty().WithMessage("Database bilgisi yazılmalıdır!");
		RuleFor(p=> p.DatabaseName).NotNull().WithMessage("Database bilgisi yazılmalıdır!");
		RuleFor(p => p.ServerName).NotEmpty().WithMessage("Server bilgisi yazılmalıdır!");
		RuleFor(p => p.ServerName).NotNull().WithMessage("Server bilgisi yazılmalıdır!");
		RuleFor(p => p.Name).NotEmpty().WithMessage("Şirket adı yazılmalıdır!");
		RuleFor(p => p.Name).NotNull().WithMessage("Şirket adı yazılmalıdır!");		
	}
}
