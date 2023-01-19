namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public sealed record MigrateCompanyDatabasesCommandResponse(
        string Message = "Şirketletin database bilgileri migrate edildi!");
}
