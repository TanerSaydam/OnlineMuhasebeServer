using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.CreateBookEntry;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.UpdateBookEntry;
using Shouldly;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.BookEntryFeatures
{
    public sealed class UpdateBookEntryCommandUnitTest
    {
        private readonly Mock<IBookEntryService> _service;
        private readonly Mock<ILogService> _logService;
        private readonly Mock<IApiService> _apiService;

        public UpdateBookEntryCommandUnitTest()
        {
            _service = new();
            _logService = new();
            _apiService = new();
        }

        [Fact]
        public async Task UpdateBookEntryCommandResponseShouldNotBeNull()
        {
            string id = "8fd351e3-d6f1-4379-8ab4-b43463062a77";
            string companyId = "8fd351e3-d6f1-4379-8ab4-b43463062a77";

            _service.Setup(s =>
            s.GetByIdAsync(id, companyId)).ReturnsAsync(new BookEntry());

            UpdateBookEntryCommand command = new(
                Id: id,
                CompanyId: companyId,
                Type: "Muavin",
                Description: "Yevmiye Fişi",
                Date: "12.02.2023");

            UpdateBookEntryCommandHandler handler = new(_service.Object, _apiService.Object, _logService.Object);
            UpdateBookEntryCommandResponse response = await handler.Handle(command, default);

            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
