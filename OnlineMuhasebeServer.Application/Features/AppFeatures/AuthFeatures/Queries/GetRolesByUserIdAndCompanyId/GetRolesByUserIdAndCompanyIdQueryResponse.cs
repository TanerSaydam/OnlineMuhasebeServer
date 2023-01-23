namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AuthFeatures.Queries.GetRolesByUserIdAndCompanyId;

public sealed record GetRolesByUserIdAndCompanyIdQueryResponse(
    IList<string> Roles);
