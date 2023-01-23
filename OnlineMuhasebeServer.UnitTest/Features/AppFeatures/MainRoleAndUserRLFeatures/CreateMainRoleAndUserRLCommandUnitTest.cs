using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.CreateMainRoleAndUserRL;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.MainRoleAndUserRLFeatures;

public sealed class CreateMainRoleAndUserRLCommandUnitTest
{
    private readonly Mock<IMainRoleAndUserRelationshipService> _serviceMock;

    public CreateMainRoleAndUserRLCommandUnitTest()
    {
        _serviceMock = new();
    }

    [Fact]
    public async Task MainRoleAndUserRelationshipShouldBeNull()
    {
        MainRoleAndUserRelationship entity = await _serviceMock.Object.GetByUserIdCompanyIdAndMainRoleIdAsync(
            userId: "d43a86e8-091a-4c6f-b7eb-a94309b1a706",
            companyId: "23d81291-9f85-43f2-8de6-76aa5b038541",
            mainRoleId: "5ea90e24-bb1d-4981-950b-cea5008115dc",
            cancellationToken: default);

        entity.ShouldBeNull();
    }

    [Fact]
    public async Task CreateMainRoleAndUserRLCommandResponseShouldNotBeNull()
    {
        CreateMainRoleAndUserRLCommand command = new(
            UserId: "d43a86e8-091a-4c6f-b7eb-a94309b1a706",
            MainRoleId: "5ea90e24-bb1d-4981-950b-cea5008115dc",
            CompanyId: "23d81291-9f85-43f2-8de6-76aa5b038541");

        CreateMainRoleAndUserRLCommandHandler handler = new(_serviceMock.Object);
        CreateMainRoleAndUserRLCommandResponse response = await handler.Handle(command, default);

        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
