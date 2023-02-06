using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.CompanyServices;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateMainUCAF;

public sealed class CreateMainUCAFCommandHandler : ICommandHandler<CreateMainUCAFCommand, CreateMainUCAFCommandResponse>
{
    private readonly IUCAFService _ucafService;

    public CreateMainUCAFCommandHandler(IUCAFService ucafService)
    {
        _ucafService = ucafService;
    }

    public async Task<CreateMainUCAFCommandResponse> Handle(CreateMainUCAFCommand request, CancellationToken cancellationToken)
    {
        await _ucafService.CreateMainUcafsToCompanyAsync(request.CompanyId, cancellationToken);
        return new();
    }
}
