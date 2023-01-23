using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.RemoveByIdMainRoleAndRoleRL;

public sealed class RemoveByIdMainRoleAndRoleRLCommandHandler : ICommandHandler<RemoveByIdMainRoleAndRoleRLCommand, RemoveByIdMainRoleAndRoleRLCommandResponse>
{
    private readonly IMainRoleAndRoleRelationshipService _roleRelationshipService;

    public RemoveByIdMainRoleAndRoleRLCommandHandler(IMainRoleAndRoleRelationshipService roleRelationshipService)
    {
        _roleRelationshipService = roleRelationshipService;
    }

    public async Task<RemoveByIdMainRoleAndRoleRLCommandResponse> Handle(RemoveByIdMainRoleAndRoleRLCommand request, CancellationToken cancellationToken)
    {
        MainRoleAndRoleRelationship entity = await _roleRelationshipService.GetByIdAsync(request.Id);
        if (entity == null) throw new Exception("Belirtilen Ana Rol ve Rol bağlantısı bulunamadı!");

        await _roleRelationshipService.RemoveByIdAsync(request.Id);
        return new();
    }
}
