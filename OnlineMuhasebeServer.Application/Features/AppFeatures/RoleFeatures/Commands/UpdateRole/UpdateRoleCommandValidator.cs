using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;

public sealed class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id bilgisi boş olamaz!");
        RuleFor(p => p.Id).NotNull().WithMessage("Id bilgisi boş olamaz!!"); 
        RuleFor(p => p.Code).NotEmpty().WithMessage("Role kodu boş olamaz!");
        RuleFor(p => p.Code).NotNull().WithMessage("Role kodu boş olamaz!");
        RuleFor(p => p.Name).NotEmpty().WithMessage("Role adı boş olamaz!");
        RuleFor(p => p.Name).NotNull().WithMessage("Role adı boş olamaz!");
    }
}
