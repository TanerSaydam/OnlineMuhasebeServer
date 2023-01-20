using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.RoleFeatures.Commands;

public sealed class DeleteRoleCommandUnitTest
{
    private readonly Mock<IRoleService> _roleServiceMock;

    public DeleteRoleCommandUnitTest()
    {
        _roleServiceMock = new();
    }

    [Fact]
    public async Task AppRoleShouldNotBeNull()
    {
        _roleServiceMock.Setup(
            x => x.GetById(It.IsAny<string>()))
            .ReturnsAsync(new AppRole());
    }

    [Fact]
    public async Task DeleteRoleCommandResponseShouldNotBeNull()
    {
        var command = new DeleteRoleCommand(
            Id: "585985c0-4576-4d62-ae67-59a6f72ae906");

        _roleServiceMock.Setup(
            x => x.GetById(It.IsAny<string>()))
            .ReturnsAsync(new AppRole());

        var handler = new DeleteRoleCommandHandler(_roleServiceMock.Object);
        DeleteRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
