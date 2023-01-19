using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Persistance.Services.AppServices
{
    public sealed class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateRoleRequest request)
        {
            AppRole role = _mapper.Map<AppRole>(request);
            role.Id = Guid.NewGuid().ToString();
            await _roleManager.CreateAsync(role);
        }

        public async Task DeleteAsync(AppRole appRole)
        {            
            await _roleManager.DeleteAsync(appRole);
        }

        public async Task<IList<AppRole>> GetAllRolesAsync()
        {
            IList<AppRole> roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }

        public async Task<AppRole> GetByCode(string code)
        {
            AppRole role = await _roleManager.Roles.FirstOrDefaultAsync(p=> p.Code == code);
            return role;
        }

        public async Task<AppRole> GetById(string id)
        {
            AppRole role = await _roleManager.FindByIdAsync(id);
            return role;
        }

        public async Task UpdateAsync(AppRole appRole)
        {
            await _roleManager.UpdateAsync(appRole);
        }
    }
}
