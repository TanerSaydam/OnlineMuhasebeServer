namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AppUserFeatures.Login
{
    public sealed record LoginCommandResponse(
        string Token,
        string Email,
        string UserId,
        string NameLastName);
}
