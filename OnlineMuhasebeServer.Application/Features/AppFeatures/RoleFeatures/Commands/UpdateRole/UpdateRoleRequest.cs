using MediatR;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole
{
    public sealed class UpdateRoleRequest : IRequest<UpdateRoleReponse>
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
