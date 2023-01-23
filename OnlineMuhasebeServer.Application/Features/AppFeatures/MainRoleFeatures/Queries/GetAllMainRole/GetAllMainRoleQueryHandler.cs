using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Queries.GetAllMainRole;

public sealed class GetAllMainRoleQueryHandler : IQueryHander<GetAllMainRoleQuery, GetAllMainRoleQueryResponse>
{
    private readonly IMainRoleService _mainRoleService;

    public GetAllMainRoleQueryHandler(IMainRoleService mainRoleService)
    {
        _mainRoleService = mainRoleService;
    }

    public async Task<GetAllMainRoleQueryResponse> Handle(GetAllMainRoleQuery request, CancellationToken cancellationToken)
    {
        var result = _mainRoleService.GetAll();
        return new(await result.ToListAsync());
    }
}
