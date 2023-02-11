using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineMuhasebeServer.Domain.Dtos;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.LogFeatures.Queires.GetLogsByTableName;

public sealed record GetLogsByTableNameQueryResponse(PaginationResult<LogDto> Data);
