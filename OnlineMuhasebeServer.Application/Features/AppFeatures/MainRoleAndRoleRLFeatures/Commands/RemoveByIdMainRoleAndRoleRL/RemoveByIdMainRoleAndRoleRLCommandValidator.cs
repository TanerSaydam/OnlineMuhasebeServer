using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.RemoveByIdMainRoleAndRoleRL;

public sealed class RemoveByIdMainRoleAndRoleRLCommandValidator : AbstractValidator<RemoveByIdMainRoleAndRoleRLCommand>
{
    public RemoveByIdMainRoleAndRoleRLCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id alanı zorunludur!");
        RuleFor(p => p.Id).NotNull().WithMessage("Id alanı zorunludur!");
    }
}
