using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.MainRoleFeatures;

public sealed class UpdateMainRoleCommandUnitTest
{
    private readonly Mock<IMainRoleService> _mainRoleService;

    public UpdateMainRoleCommandUnitTest()
    {
        _mainRoleService = new();
    }

    [Fact]
    public async Task MainRoleShouldNotBeNull()
    {
        _mainRoleService
            .Setup(x=> x.GetByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(new MainRole());        
    }

    [Fact]
    public async Task UpdateMainRoleCommandResponseShouldNotBeNull()
    {
        var command = new UpdateMainRoleCommand(
            Id: "585985c0-4576-4d62-ae67-59a6f72ae906",
            Title: "Admin");

        var handler = new UpdateMainRoleCommandHandler(_mainRoleService.Object);

        _mainRoleService
           .Setup(x => x.GetByIdAsync(It.IsAny<string>()))
           .ReturnsAsync(new MainRole());

        UpdateMainRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
