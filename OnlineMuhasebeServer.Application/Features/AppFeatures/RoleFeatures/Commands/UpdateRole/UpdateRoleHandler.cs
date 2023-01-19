using MediatR;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole
{
    public sealed class UpdateRoleHandler : IRequestHandler<UpdateRoleRequest, UpdateRoleReponse>
    {
        private readonly IRoleService _roleService;

        public UpdateRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<UpdateRoleReponse> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleService.GetById(request.Id);
            if (role == null) throw new Exception("Role bulunamadı!");

            if(role.Code != request.Code)
            {
                AppRole checkCode = await _roleService.GetByCode(request.Code);
                if (checkCode != null) throw new Exception("Bu kod daha önce kaydedilmiş!");
            }

            role.Code = request.Code;
            role.Name = request.Name;
            await _roleService.UpdateAsync(role);
            return new();
        }
    }
}
