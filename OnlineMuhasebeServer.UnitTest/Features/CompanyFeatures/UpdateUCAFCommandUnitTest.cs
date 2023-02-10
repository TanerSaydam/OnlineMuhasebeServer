using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.UpdateUCAF;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures
{
    public sealed class UpdateUCAFCommandUnitTest
    {
        private readonly Mock<IUCAFService> _service;

        public UpdateUCAFCommandUnitTest()
        {
            _service = new();
        }

        [Fact]
        public async Task UniformChartOfAccountShouldNotBeNull()
        {
            _service.Setup(s=>
            s.GetByIdAsync(
                It.IsAny<string>(),
                It.IsAny<string>()))
                .ReturnsAsync(new UniformChartOfAccount());
        }

        [Fact]
        public async Task CheckNewUCAFCodeShouldBeNull()
        {
            string companyId = "585985c0-4576-4d62-ae67-59a6f72ae906";
            string code = "100.01.001";
            UniformChartOfAccount ucaf = await _service.Object.GetByCodeAsync(companyId, code, default);
            ucaf.ShouldBeNull();
        }

        [Fact]
        public async Task UpdateUCAFCommandResponseShouldNotBeNull()
        {
            UpdateUCAFCommand command = new(
                Id: "04ae9586-7983-42c1-be82-d49d59037003",
                Code: "100.01.001",
                Name: "MERKEZ KASA",
                Type: "M",
                CompanyId: "585985c0-4576-4d62-ae67-59a6f72ae906");

            await UniformChartOfAccountShouldNotBeNull();

            UpdateUCAFCommandHandler handler = new UpdateUCAFCommandHandler(_service.Object);

            UpdateUCAFCommandResponse response = await handler.Handle(command, default);

            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
