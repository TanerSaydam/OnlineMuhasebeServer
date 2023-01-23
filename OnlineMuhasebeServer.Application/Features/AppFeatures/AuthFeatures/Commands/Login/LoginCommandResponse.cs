using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Dtos;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AuthFeatures.Commands.Login
{
    public sealed record LoginCommandResponse(
        TokenRefreshTokenDto Token,
        string Email,
        string UserId,
        string NameLastName,
        IList<CompanyDto> Companies,
        CompanyDto Company);
}
