using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.CreateMainRoleAndRoleRL;

public sealed record CreateMainRoleAndRoleRLCommandHandler : ICommandHandler<CreateMainRoleAndRoleRLCommand, CreateMainRoleAndRoleRLCommandResponse>
{
    private readonly IMainRoleAndRoleRelationshipService _mainRoleAndRoleRelationshipService;

    public CreateMainRoleAndRoleRLCommandHandler(IMainRoleAndRoleRelationshipService mainRoleAndRoleRelationshipService)
    {
        _mainRoleAndRoleRelationshipService = mainRoleAndRoleRelationshipService;
    }

    public async Task<CreateMainRoleAndRoleRLCommandResponse> Handle(CreateMainRoleAndRoleRLCommand request, CancellationToken cancellationToken)
    {
        MainRoleAndRoleRelationship checkRoleAndMainRoleIsRelated = await _mainRoleAndRoleRelationshipService.GetByRoleIdAndMainRoleId(request.RoleId, request.MainRoleId, cancellationToken);

        if (checkRoleAndMainRoleIsRelated != null) throw new Exception("Bu rol ilişlişi daha önce kurulmuş!");

        MainRoleAndRoleRelationship mainRoleAndRoleRelationship = new(
            Guid.NewGuid().ToString(),
            request.RoleId,
            request.MainRoleId);

        await _mainRoleAndRoleRelationshipService.CreateAsync(mainRoleAndRoleRelationship, cancellationToken);
        return new();
    }
}
