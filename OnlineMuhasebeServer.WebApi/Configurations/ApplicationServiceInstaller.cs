using FluentValidation;
using MediatR;
using OnlineMuhasebeServer.Application;
using OnlineMuhasebeServer.Application.Behavior;

namespace OnlineMuhasebeServer.WebApi.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(AssemblyReference).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), (typeof(ValidationBehavior<,>)));

            services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
        }
    }
}
