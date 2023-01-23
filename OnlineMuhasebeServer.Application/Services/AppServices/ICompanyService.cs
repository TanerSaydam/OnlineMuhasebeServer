using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Services.AppServices
{
    public interface ICompanyService
    {
        Task CreateCompany(CreateCompanyCommand request, CancellationToken cancellationToken);
        Task MigrateCompanyDatabases();
        Task<Company?> GetCompanyByName(string name, CancellationToken cancellationToken);
        IQueryable<Company> GetAll();
    }
}
