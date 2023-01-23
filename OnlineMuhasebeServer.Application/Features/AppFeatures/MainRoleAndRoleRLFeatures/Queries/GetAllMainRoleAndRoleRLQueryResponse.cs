using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Queries;

public sealed record GetAllMainRoleAndRoleRLQueryResponse(
    List<MainRoleAndRoleRelationship> mainRoleAndRoleRelationships);
