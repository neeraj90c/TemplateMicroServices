using MediatR;
using RolesService.DTO;
using RolesService.Interface;

namespace RolesService.Command
{
    public class RolesCRUDCommand : IRequest<RolesList>
    {
        public RolesDTO rolesDTO { get; set; }
    }
    internal class RolesHandler : IRequestHandler<RolesCRUDCommand, RolesList>
    {
        protected readonly IRole _role;

        public RolesHandler(IRole role)
        {
            _role = role;
        }
        public async Task<RolesList> Handle(RolesCRUDCommand request, CancellationToken cancellationToken)
        {
            return await _role.ManageRoles(request.rolesDTO);
        }
    }
}
