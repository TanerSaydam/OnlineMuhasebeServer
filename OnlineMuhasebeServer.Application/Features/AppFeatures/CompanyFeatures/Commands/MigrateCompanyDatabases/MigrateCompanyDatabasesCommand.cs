using MediatR;
using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public sealed record MigrateCompanyDatabasesCommand() : ICommand<MigrateCompanyDatabasesCommandResponse>;
}
