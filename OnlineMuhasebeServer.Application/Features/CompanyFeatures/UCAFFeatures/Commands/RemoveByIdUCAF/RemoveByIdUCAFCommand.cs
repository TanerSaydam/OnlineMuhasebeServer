using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.RemoveByIdUCAF;

public sealed record RemoveByIdUCAFCommand(
    string Id,
    string CompanyId) 
    : ICommand<RemoveByIdUCAFCommandResponse>;
