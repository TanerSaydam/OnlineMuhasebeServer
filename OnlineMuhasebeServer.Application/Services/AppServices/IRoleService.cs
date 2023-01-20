using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Services.AppServices
{
    public interface IRoleService
    {
        Task AddAsync(CreateRoleCommand request);
        Task AddRangeAsync(IEnumerable<AppRole> roles);
        Task UpdateAsync(AppRole appRole);
        Task DeleteAsync(AppRole appRole);
        Task<IList<AppRole>> GetAllRolesAsync();
        Task<AppRole> GetById(string id);        
        Task<AppRole> GetByCode(string code);        
    }
}
