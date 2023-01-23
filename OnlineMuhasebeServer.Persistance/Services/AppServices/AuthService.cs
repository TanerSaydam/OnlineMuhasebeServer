using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Persistance.Services.AppServices;

public sealed class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserAndCompanyRelationshipService _companyRelationService;
    private readonly IMainRoleAndUserRelationshipService _mainRoleAndUserRelationshipService;
    private readonly IMainRoleAndRoleRelationshipService _mainRoleAndRoleRelationshipService;

    public AuthService(UserManager<AppUser> userManager, IUserAndCompanyRelationshipService companyRelationService, IMainRoleAndUserRelationshipService mainRoleAndUserRelationshipService, IMainRoleAndRoleRelationshipService mainRoleAndRoleRelationshipService)
    {
        _userManager = userManager;
        _companyRelationService = companyRelationService;
        _mainRoleAndUserRelationshipService = mainRoleAndUserRelationshipService;
        _mainRoleAndRoleRelationshipService = mainRoleAndRoleRelationshipService;
    }

    public async Task<bool> CheckPasswordAsync(AppUser user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<AppUser> GetByEmailOrUserNameAsync(string emailOrUserName)
    {
        return await _userManager.Users.Where(p => p.Email == emailOrUserName || p.UserName == emailOrUserName).FirstOrDefaultAsync();
    }

    public async Task<IList<UserAndCompanyRelationship>> GetCompanyListByUserIdAsync(string userId)
    {
        return await _companyRelationService.GetListByUserId(userId);
    }

    public async Task<IList<string>> GetRolesByUserIdAndCompanyId(string userId, string companyId)
    {
        MainRoleAndUserRelationship mainRoleAndUserRelationship = await _mainRoleAndUserRelationshipService.GetRolesByUserIdAndCompanyId(userId,companyId);

        IList<MainRoleAndRoleRelationship> getMainRole = await _mainRoleAndRoleRelationshipService.GetListByMainRoleIdForGetRolesAsync(mainRoleAndUserRelationship.MainRoleId);

        IList<string> roles = getMainRole.Select(s => s.AppRole.Name).ToList();
        return roles;
    }
}
