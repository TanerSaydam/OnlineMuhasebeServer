using OnlineMuhasebeServer.Application.Abstractions;
using OnlineMuhasebeServer.Infrasturcture.Authentication;

namespace OnlineMuhasebeServer.WebApi.Configurations
{
    public class InfrustructureDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtProvider,JwtProvider>();
        }
    }
}
