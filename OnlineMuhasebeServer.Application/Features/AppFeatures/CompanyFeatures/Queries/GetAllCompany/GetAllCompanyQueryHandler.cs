using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Queries.GetAllCompany;

public sealed class GetAllCompanyQueryHandler : IQueryHander<GetAllCompanyQuery, GetAllCompanyQueryResponse>
{
    private readonly ICompanyService _companyService;

    public GetAllCompanyQueryHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public async Task<GetAllCompanyQueryResponse> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
    {
        var result = _companyService.GetAll();
        return new GetAllCompanyQueryResponse(await result.ToListAsync());
    }
}
