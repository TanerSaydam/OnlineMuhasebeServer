using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.RemoveByIdUserAndCompanyRL;
using OnlineMuhasebeServer.Application.Services.AppServices;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.UserAndCompanyRLFeatures;

public sealed class RemoveByIdUserAndCompanyRLCommandUnitTest
{
    private readonly Mock<IUserAndCompanyRelationshipService> _serviceMock;

    public RemoveByIdUserAndCompanyRLCommandUnitTest()
    {
        _serviceMock = new();
    }

    [Fact]
    public async Task RemoveByIdUserAndCompanyRLCommandResponseShouldNotBeNull()
    {
        RemoveByIdUserAndCompanyRLCommand command = new(
            Id: "984795a4-fa9a-4ea0-8e42-b2652221aa98");

        RemoveByIdUserAndCompanyRLCommandHandler handler = new(_serviceMock.Object);
        RemoveByIdUserAndCompanyRLCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
