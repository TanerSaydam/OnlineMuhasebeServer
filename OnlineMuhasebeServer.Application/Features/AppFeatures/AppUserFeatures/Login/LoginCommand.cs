using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AppUserFeatures.Login
{
    public sealed record LoginCommand(
        string EmailOrUserName,
        string Password) : ICommand<LoginCommandResponse>;
}
