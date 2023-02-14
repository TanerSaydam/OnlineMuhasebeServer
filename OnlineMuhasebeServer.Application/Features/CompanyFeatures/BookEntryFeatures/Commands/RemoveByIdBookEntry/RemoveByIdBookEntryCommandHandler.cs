using Newtonsoft.Json;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.RemoveByIdBookEntry;

public sealed class RemoveByIdBookEntryCommandHandler : ICommandHandler<RemoveByIdBookEntryCommand, RemoveByIdBookEntryCommandResponse>
{
    private readonly IBookEntryService _bookEntryService;
    private readonly ILogService _logService;
    private readonly IApiService _apiService;

    public RemoveByIdBookEntryCommandHandler(IBookEntryService bookEntryService, ILogService logService, IApiService apiService)
    {
        _bookEntryService = bookEntryService;
        _logService = logService;
        _apiService = apiService;
    }

    public async Task<RemoveByIdBookEntryCommandResponse> Handle(RemoveByIdBookEntryCommand request, CancellationToken cancellationToken)
    {
        BookEntry bookEntry = await _bookEntryService.RemoveByIdAsync(request.Id, request.CompanyId);

        Log log = new()
        {
            Id = Guid.NewGuid().ToString(),
            Data = JsonConvert.SerializeObject(bookEntry),
            CreatedDate = DateTime.Now,
            TableName = nameof(BookEntry),
            UserId = _apiService.GetUserIdByToken(),
            Progress = "Delete"
        };

        await _logService.AddAsync(log,request.CompanyId);

        return new();
    }
}
