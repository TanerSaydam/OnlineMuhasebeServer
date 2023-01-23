using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.CreateMainRoleAndRoleRL;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.MainRoleAndRoleRLFeatures;

public sealed class CreateMainRoleAndRoleRLCommandUnitTest
{
    private readonly Mock<IMainRoleAndRoleRelationshipService> _service;

    public CreateMainRoleAndRoleRLCommandUnitTest()
    {
        _service = new();
    }

    [Fact]
    public async Task MainRoleAndRoleRelationshipShouldBeNull()
    {
        MainRoleAndRoleRelationship entity = (await _service.Object.GetByRoleIdAndMainRoleId(
            roleId: "ab89c723-6086-4d67-b2fd-407bfc0b3f2d",
            mainRoleId: "58986c90-54d0-4f21-968e-c10b30bfee66",
            cancellationToken: default))!;
        entity.ShouldBeNull();
    }

    [Fact]
    public async Task CreateMainRoleAndRoleRLCommandResponseShouldNotBeNull()
    {
        var command = new CreateMainRoleAndRoleRLCommand(
            RoleId: "ab89c723-6086-4d67-b2fd-407bfc0b3f2d",
            MainRoleId: "58986c90-54d0-4f21-968e-c10b30bfee66");

        var handler = new CreateMainRoleAndRoleRLCommandHandler(_service.Object);


        CreateMainRoleAndRoleRLCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
