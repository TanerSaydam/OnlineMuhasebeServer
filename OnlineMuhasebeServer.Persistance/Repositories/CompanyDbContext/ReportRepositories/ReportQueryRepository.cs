using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.CompanyDbContext;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.ReportRepositories;

namespace OnlineMuhasebeServer.Persistance.Repositories.CompanyDbContext.ReportRepositories;

public class ReportQueryRepository : CompanyDbQueryRepository<Report>, IReportQueryRepository
{

}
