using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.CreateBookEntry;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Queries.GetAllBookEntry;
using OnlineMuhasebeServer.Presentation.Abstraction; 

namespace OnlineMuhasebeServer.Presentation.Controller;

[Authorize(AuthenticationSchemes ="Bearer")]
public class BookEntriesController : ApiController
{
    public BookEntriesController(IMediator mediator) : base(mediator) {}

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateBookEntry(CreateBookEntryCommand request,CancellationToken cancellationToken)
    {
        CreateBookEntryCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllBookEntry(GetAllBookEntryQuery request)
    {
        PaginationResult<GetAllBookEntryQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }
}
