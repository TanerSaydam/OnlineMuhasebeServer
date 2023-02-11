
using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Services.CompanyServices;

public interface IReportService
{
    Task Request(RequestReportCommand request, CancellationToken cancellationToken);
    Task<PaginationResult<Report>> GetAllReportsByCompanyId(string companyId, int PageNumber = 1, int pageSize = 5);
}
