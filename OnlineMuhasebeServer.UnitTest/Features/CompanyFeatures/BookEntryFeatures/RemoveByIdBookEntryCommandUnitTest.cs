using Microsoft.Identity.Client;
using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.RemoveByIdBookEntry;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.BookEntryFeatures
{
    public sealed class RemoveByIdBookEntryCommandUnitTest
    {
        private readonly Mock<IBookEntryService> _service;
        private readonly Mock<ILogService> _logService;
        private readonly Mock<IApiService> _apiService;

        public RemoveByIdBookEntryCommandUnitTest()
        {
            _apiService = new();
            _logService = new();
            _service = new();
        }

        [Fact]
        public async Task RemoveByIdBookEntryCommandResponseShouldNotBeNull()
        {
            RemoveByIdBookEntryCommand command = new(
                Id: "8fd351e3-d6f1-4379-8ab4-b43463062a77",
                CompanyId: "ae3d3b62-dcaf-4bbf-9c8c-7560fc758248");

            RemoveByIdBookEntryCommandHandler handler = new RemoveByIdBookEntryCommandHandler(_service.Object, _logService.Object, _apiService.Object);

            RemoveByIdBookEntryCommandResponse response = await handler.Handle(command, default);

            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
