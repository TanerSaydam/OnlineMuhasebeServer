using OnlineMuhasebeServer.Application.Abstractions;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Infrasturcture.Authentication;
using OnlineMuhasebeServer.Infrasturcture.Services;

namespace OnlineMuhasebeServer.WebApi.Configurations
{
    public class InfrustructureDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtProvider,JwtProvider>();
            services.AddScoped<IRabbitMQService,RabbitMQService>();
        }
    }
}
