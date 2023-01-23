using Azure.Core;
using MediatR;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Services.AppServices;

public interface IMainRoleService
{
    Task<MainRole> GetByTitleAndCompanyId(string title, string companyId, CancellationToken cancellationToken);
    Task CreateAsync(MainRole mainRole, CancellationToken cancellationToken);
    Task CreateRangeAsync(List<MainRole> newMainRoles, CancellationToken cancellationToken);
    IQueryable<MainRole> GetAll();
    Task RemoveByIdAsync(string id);
    Task<MainRole> GetByIdAsync(string id);
    Task UpdateAsync(MainRole mainRole);
}
