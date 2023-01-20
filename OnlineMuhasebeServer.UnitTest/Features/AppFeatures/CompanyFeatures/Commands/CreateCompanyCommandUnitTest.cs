using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.CompanyFeatures.Commands;

public sealed class CreateCompanyCommandUnitTest
{
    private readonly Mock<ICompanyService> _companyService;

    public CreateCompanyCommandUnitTest()
    {
        _companyService = new();
    }

    [Fact]
    public async Task CompanyShouldBeNull()
    {
        Company company = (await _companyService.Object.GetCompanyByName("Saydam Ltd Şti"))!;
        company.ShouldBeNull();
    }

    [Fact]
    public async Task CreateCompanyCommandResponseShouldNotBeNull()
    {
        var command = new CreateCompanyCommand(
            Name:"Saydam Ltd Şti",
           ServerName: "localhost",
           DatabaseName: "SaydamMuhasebeDb",
           UserId: "",
           Password: "");

        var handler = new CreateCompanyCommandHandler(_companyService.Object);


        CreateCompanyCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
