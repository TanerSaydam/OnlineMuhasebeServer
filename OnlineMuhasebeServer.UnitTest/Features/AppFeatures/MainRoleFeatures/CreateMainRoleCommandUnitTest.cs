using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.MainFeatures;

public sealed class CreateMainRoleCommandUnitTest
{
    private readonly Mock<IMainRoleService> _mainRoleService;

    public CreateMainRoleCommandUnitTest()
    {
        _mainRoleService = new();
    }

    [Fact]
    public async Task MainRoleShouldBeNull()
    {
        MainRole mainRole = await _mainRoleService.Object.GetByTitleAndCompanyId(
            title: "Admin",
            companyId: "585985c0-4576-4d62-ae67-59a6f72ae906",
            default
            );
        mainRole.ShouldBeNull();
    }

    [Fact]
    public async Task CreateMainRoleCommandResponseShouldNotBeNull()
    {
        var command = new CreateMainRoleCommand(
            Title: "Admin",
            IsRoleCreatedByAdmin: false,            
            CompanyId: "585985c0-4576-4d62-ae67-59a6f72ae906");

        var handler = new CreateMainRoleCommandHandler(_mainRoleService.Object);

        CreateMainRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
