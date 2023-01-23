using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.RoleFeatures;

public sealed class UpdateRoleCommandUnitTest
{
    private readonly Mock<IRoleService> _roleServiceMock;

    public UpdateRoleCommandUnitTest()
    {
        _roleServiceMock = new();
    }

    [Fact]
    public async Task AppRoleShouldNotBe()
    {
        _roleServiceMock.Setup(
            x => x.GetById(It.IsAny<string>()))
            .ReturnsAsync(new AppRole());
    }

    [Fact]
    public async Task AppRoleCodeShouldBeUniqe()
    {
        AppRole checkRoleCode = await _roleServiceMock.Object.GetByCode("UCAF.Create");
        checkRoleCode.ShouldBeNull();
    }

    [Fact]
    public async Task UpdateRoleCommandResponseShouldNotBeNull()
    {
        var command = new UpdateRoleCommand(
            Id: "486083b2-57f1-4a72-b72b-55bf752a2d31",
            Code: "UCAF.Create",
            Name: "Hesap Planı Kayıt Ekleme");

        _roleServiceMock.Setup(
            x => x.GetById(It.IsAny<string>()))
            .ReturnsAsync(new AppRole());

        var handler = new UpdateRoleCommandHandler(_roleServiceMock.Object);

        UpdateRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
