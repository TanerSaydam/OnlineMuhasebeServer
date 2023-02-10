using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.UpdateUCAF;

public sealed class UpdateUCAFCommandHandler : ICommandHandler<UpdateUCAFCommand, UpdateUCAFCommandResponse>
{
    private readonly IUCAFService _service;

    public UpdateUCAFCommandHandler(IUCAFService service)
    {
        _service = service;
    }

    public async Task<UpdateUCAFCommandResponse> Handle(UpdateUCAFCommand request, CancellationToken cancellationToken)
    {
        UniformChartOfAccount ucaf = await _service.GetByIdAsync(request.Id, request.CompanyId);

        if (ucaf == null) throw new Exception("Hesap planı bulunamadı!");

        if(ucaf.Code != request.Code)
        {
            UniformChartOfAccount checkNewCode = await _service.GetByCodeAsync(request.CompanyId, request.Code, cancellationToken);
            if (checkNewCode != null) throw new Exception("Bu hesap planı kodu daha önce kullanılmış!");
        }

        if (request.Type != "G" && request.Type != "M") throw new Exception("Hesap planı türü Grup ya da Muavin olmalıdır!");

        ucaf.Type = request.Type == "G" ? 'G' : 'M';
        ucaf.Code = request.Code;
        ucaf.Name = request.Name;

        await _service.UpdateAsync(ucaf, request.CompanyId);

        return new();
    }
}
