using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.RemoveByIdUCAF;

public sealed class RemoveByIdUCAFCommandHandler : ICommandHandler<RemoveByIdUCAFCommand, RemoveByIdUCAFCommandResponse>
{
    private readonly IUCAFService _service;

    public RemoveByIdUCAFCommandHandler(IUCAFService service)
    {
        _service = service;
    }

    public async Task<RemoveByIdUCAFCommandResponse> Handle(RemoveByIdUCAFCommand request, CancellationToken cancellationToken)
    {
        var checkRemoveUcafById = await _service.CheckRemoveByIdUcafIsGroupAndAvailable(request.Id, request.CompanyId);

        if (!checkRemoveUcafById) throw new Exception("Hesap planına bağlı alt hesaplar olduğundan silinemiyor!");

        await _service.RemoveByIdUcafAsync(request.Id, request.CompanyId);

        return new();
    }
}
