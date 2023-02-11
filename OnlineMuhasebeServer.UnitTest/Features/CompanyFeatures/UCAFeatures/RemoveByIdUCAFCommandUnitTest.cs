using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.RemoveByIdUCAF;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.UCAFeatures;

public sealed class RemoveByIdUCAFCommandUnitTest
{
    private readonly Mock<IUCAFService> _ucafService;
    private readonly Mock<IApiService> _apiService;
    private readonly Mock<ILogService> _logService;

    public RemoveByIdUCAFCommandUnitTest()
    {
        _ucafService = new();
        _apiService = new();
        _logService = new();
    }

    [Fact]
    public async Task CheckRemoveByIdUcafIsGroupAndAvailableShouldBeTrue()
    {
        _ucafService.Setup(s =>
        s.CheckRemoveByIdUcafIsGroupAndAvailable(
            It.IsAny<string>(),
            It.IsAny<string>()))
            .ReturnsAsync(true);
    }

    [Fact]
    public async Task RemoveByIdUCAFCommandResponseShouldNotBeNull()
    {
        var command = new RemoveByIdUCAFCommand(
            Id: "01c16882-d379-4a51-8c28-18c07841e71c",
            CompanyId: "585985c0-4576-4d62-ae67-59a6f72ae906");

        await CheckRemoveByIdUcafIsGroupAndAvailableShouldBeTrue();

        var handler = new RemoveByIdUCAFCommandHandler(_ucafService.Object, _logService.Object, _apiService.Object);

        RemoveByIdUCAFCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
