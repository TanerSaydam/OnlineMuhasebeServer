using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.ReportFeatures.Queries.GetAllReport;

public sealed record GetAllReportQueryResponse(
    PaginationResult<Report> Data);
