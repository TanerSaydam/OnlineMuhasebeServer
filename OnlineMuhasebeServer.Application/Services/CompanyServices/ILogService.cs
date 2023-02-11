
using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.LogFeatures.Queires.GetLogsByTableName;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Dtos;

namespace OnlineMuhasebeServer.Application.Services.CompanyServices;

public interface ILogService
{
    Task AddAsync(Log log, string companyId);
    Task<PaginationResult<LogDto>> GetAllByTableName(GetLogsByTableNameQuery request);
}
