using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Queries.GetAllCompany;
using OnlineMuhasebeServer.Presentation.Abstraction;

namespace OnlineMuhasebeServer.Presentation.Controller
{
    public class CompaniesController : ApiController
    {
        public CompaniesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCompany(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            CreateCompanyCommandResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> MigrateCompanyDatabases()
        {
            MigrateCompanyDatabasesCommand request = new();
            MigrateCompanyDatabasesCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCompany()
        {
            GetAllCompanyQuery request = new();
            GetAllCompanyQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
