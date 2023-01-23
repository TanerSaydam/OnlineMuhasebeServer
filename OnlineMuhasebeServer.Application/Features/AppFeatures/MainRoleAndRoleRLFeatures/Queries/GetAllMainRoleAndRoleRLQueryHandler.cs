using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Queries;

public sealed class GetAllMainRoleAndRoleRLQueryHandler : IQueryHander<GetAllMainRoleAndRoleRLQuery, GetAllMainRoleAndRoleRLQueryResponse>
{
    private readonly IMainRoleAndRoleRelationshipService _roleRelationshipService;

    public GetAllMainRoleAndRoleRLQueryHandler(IMainRoleAndRoleRelationshipService roleRelationshipService)
    {
        _roleRelationshipService = roleRelationshipService;
    }

    public async Task<GetAllMainRoleAndRoleRLQueryResponse> Handle(GetAllMainRoleAndRoleRLQuery request, CancellationToken cancellationToken)
    {
        return new(await _roleRelationshipService
            .GetAll()
            .Include("AppRole")
            .Include("MainRole")
            .ToListAsync());
    }
}
