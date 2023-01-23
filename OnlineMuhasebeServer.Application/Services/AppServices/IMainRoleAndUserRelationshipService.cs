
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Services.AppServices;

public interface IMainRoleAndUserRelationshipService
{
    Task CreateAsync(MainRoleAndUserRelationship mainRoleAndUserRelationship, CancellationToken cancellationToken);
    Task RemoveByIdAsync(string id);
    Task<MainRoleAndUserRelationship> GetByUserIdCompanyIdAndMainRoleIdAsync(string userId, string companyId, string mainRoleId, CancellationToken cancellationToken);

    Task<MainRoleAndUserRelationship> GetByIdAsync(string id, bool tracking);
}
