using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.ReportRepositories;

public interface IReportQueryRepository : ICompanyDbQueryRepository<Report>
{

}
