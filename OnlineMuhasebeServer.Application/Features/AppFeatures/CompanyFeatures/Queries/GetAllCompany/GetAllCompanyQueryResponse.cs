using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Queries.GetAllCompany;

public sealed record GetAllCompanyQueryResponse(
    List<Company> Companies);
