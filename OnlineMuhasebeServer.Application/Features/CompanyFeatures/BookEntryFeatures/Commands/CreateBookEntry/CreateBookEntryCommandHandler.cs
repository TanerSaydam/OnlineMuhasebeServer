using Newtonsoft.Json;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.CreateBookEntry;

public sealed class CreateBookEntryCommandHandler : ICommandHandler<CreateBookEntryCommand, CreateBookEntryCommandResponse>
{
    private readonly IBookEntryService _bookEntryService;
    private readonly ILogService _logService;
    private readonly IApiService _apiService;

    public CreateBookEntryCommandHandler(IBookEntryService bookEntryService, ILogService logService, IApiService apiService)
    {
        _bookEntryService = bookEntryService;
        _logService = logService;
        _apiService = apiService;
    }

    public async Task<CreateBookEntryCommandResponse> Handle(CreateBookEntryCommand request, CancellationToken cancellationToken)
    {
        string newBookEntryNumber = await _bookEntryService.GetNewBookEntryNumber(request.CompanyId);

        BookEntry bookEntry = new()
        {
            Id = Guid.NewGuid().ToString(),
            BookEntryNumber = newBookEntryNumber,
            Date = Convert.ToDateTime(request.Date),
            Description = request.Description,
            Type = request.Type,
        };

        await _bookEntryService.AddAsync(request.CompanyId,bookEntry, cancellationToken);
        string userId = _apiService.GetUserIdByToken();

        Log log = new()
        {
            Id = Guid.NewGuid().ToString(),
            Data = JsonConvert.SerializeObject(bookEntry),
            Progress = "Create",
            TableName = nameof(BookEntry),
            UserId = userId
        };

        await _logService.AddAsync(log,request.CompanyId);

        return new();
    }
}
