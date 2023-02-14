using Microsoft.AspNetCore.Http;
using OnlineMuhasebeServer.Application.Services;

namespace OnlineMuhasebeServer.Infrasturcture.Services;

public sealed class ApiService : IApiService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApiService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetUserIdByToken()
    {
        var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(p=> p.Type.Contains("authentication"))?.Value;
        return userId ?? string.Empty;
    }    
}
