using Newtonsoft.Json;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.UpdateUCAF;

public sealed class UpdateUCAFCommandHandler : ICommandHandler<UpdateUCAFCommand, UpdateUCAFCommandResponse>
{
    private readonly IUCAFService _service;
    private readonly ILogService _logService;
    private readonly IApiService _apiService;

    public UpdateUCAFCommandHandler(IUCAFService service, ILogService logService, IApiService apiService)
    {
        _service = service;
        _logService = logService;
        _apiService = apiService;
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
        string userId = _apiService.GetUserIdByToken();
        Log oldLog = new()
        {
            Id = Guid.NewGuid().ToString(),
            Progress = "UpdateOld",
            TableName = nameof(UniformChartOfAccount),
            Data = JsonConvert.SerializeObject(ucaf),
            UserId = userId,
        };


        ucaf.Type = request.Type == "G" ? 'G' : 'M';
        ucaf.Code = request.Code;
        ucaf.Name = request.Name;

        await _service.UpdateAsync(ucaf, request.CompanyId);

        Log newLog = new()
        {
            Id = Guid.NewGuid().ToString(),
            Progress = "UpdateNew",
            TableName = nameof(UniformChartOfAccount),
            Data = JsonConvert.SerializeObject(ucaf),
            UserId = userId
        };

        await _logService.AddAsync(oldLog, request.CompanyId);
        await _logService.AddAsync(newLog, request.CompanyId);

        return new();
    }
}
