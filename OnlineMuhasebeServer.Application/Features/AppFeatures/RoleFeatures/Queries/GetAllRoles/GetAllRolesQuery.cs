using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles
{
    public sealed record GetAllRolesQuery() : IQuery<GetAllRolesQueryResponse>;
}
