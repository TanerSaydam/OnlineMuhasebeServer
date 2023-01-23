using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.RemoveByIdMainRoleAndUserRL;

public sealed class RemoveByIdMainRoleAndUserRLCommandValidator: AbstractValidator<RemoveByIdMainRoleAndUserRLCommand>
{
    public RemoveByIdMainRoleAndUserRLCommandValidator()
    {
        RuleFor(p=> p.Id).NotEmpty().WithMessage("Id alanı boş olamaz!");
        RuleFor(p=> p.Id).NotNull().WithMessage("Id alanı boş olamaz!");
    }
}
