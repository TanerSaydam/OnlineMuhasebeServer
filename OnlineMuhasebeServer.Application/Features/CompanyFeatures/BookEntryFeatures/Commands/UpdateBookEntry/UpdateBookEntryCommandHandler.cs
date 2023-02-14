using Newtonsoft.Json;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.UpdateBookEntry;

public sealed class UpdateBookEntryCommandHandler : ICommandHandler<UpdateBookEntryCommand, UpdateBookEntryCommandResponse>
{
    private readonly IBookEntryService _bookEntryService;
    private readonly ILogService _logService;
    private readonly IApiService _apiService;
    public UpdateBookEntryCommandHandler(IBookEntryService bookEntryService, IApiService apiService, ILogService logService)
    {
        _bookEntryService = bookEntryService;
        _apiService = apiService;
        _logService = logService;
    }

    public async Task<UpdateBookEntryCommandResponse> Handle(UpdateBookEntryCommand request, CancellationToken cancellationToken)
    {
        BookEntry bookEntry = await _bookEntryService.GetByIdAsync(request.Id, request.CompanyId);

        Log oldLog = new()
        {
            Id = Guid.NewGuid().ToString(),
            Data = JsonConvert.SerializeObject(bookEntry),
            Progress = "UpdateOld",
            TableName = nameof(BookEntry),
            UserId = _apiService.GetUserIdByToken()
        };

        bookEntry.Type = request.Type;
        bookEntry.Date = Convert.ToDateTime(request.Date);
        bookEntry.Description = request.Description;
        BookEntry newBookEntry = await _bookEntryService.UpdateAsync(bookEntry, request.CompanyId);


        Log newLog = new()
        {
            Id = Guid.NewGuid().ToString(),
            Data = JsonConvert.SerializeObject(newBookEntry),
            Progress = "UpdateNew",
            TableName = nameof(BookEntry),
            UserId = _apiService.GetUserIdByToken()
        };

        await _logService.AddAsync(oldLog,request.CompanyId);
        await _logService.AddAsync(newLog, request.CompanyId);

        return new();
    }
}
