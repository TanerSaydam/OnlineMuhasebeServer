using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Queries.GetAllUCAF;

public sealed record GetAllUCAFQueryResponse(IList<UniformChartOfAccount> Data);
