using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.RemoveByIdMainRoleAndRoleRL;
using OnlineMuhasebeServer.Application.Services.AppServices;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.MainRoleAndRoleRLFeatures;

public sealed class RemoveByIdMainRoleAndRoleRLCommandUnitTest
{
    private readonly Mock<IMainRoleAndRoleRelationshipService> _serviceMock;

    public RemoveByIdMainRoleAndRoleRLCommandUnitTest()
    {
        _serviceMock = new();
    }

    [Fact]
    public async Task MainRoleAndRoleRelationshipShouldNotBeNull()
    {
        _serviceMock.Setup(s=> 
        s.GetByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(new Domain.AppEntities.MainRoleAndRoleRelationship());
    }

    [Fact]
    public async Task RemoveByIdMainRoleAndRoleRLCommandResponseShouldNotBeNull()
    {
        RemoveByIdMainRoleAndRoleRLCommand removeByIdMainRoleAndRoleRLCommand = new(
            Id: "58986c90-54d0-4f21-968e-c10b30bfee66");

        RemoveByIdMainRoleAndRoleRLCommandHandler handler = new(_serviceMock.Object);

        _serviceMock.Setup(s =>
       s.GetByIdAsync(It.IsAny<string>()))
           .ReturnsAsync(new Domain.AppEntities.MainRoleAndRoleRelationship());

        RemoveByIdMainRoleAndRoleRLCommandResponse response = await handler.Handle(removeByIdMainRoleAndRoleRLCommand, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
