using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.CompanyServices;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.LogFeatures.Queires.GetLogsByTableName;

public sealed class GetLogsByTableNameQueryHandler : IQueryHandler<GetLogsByTableNameQuery, GetLogsByTableNameQueryResponse>
{
    private readonly ILogService _logService;

    public GetLogsByTableNameQueryHandler(ILogService logService)
    {
        _logService = logService;
    }

    public async Task<GetLogsByTableNameQueryResponse> Handle(GetLogsByTableNameQuery request, CancellationToken cancellationToken)
    {
        return new(await _logService.GetAllByTableName(request));
    }
}
