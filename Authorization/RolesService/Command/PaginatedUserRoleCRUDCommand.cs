using MediatR;
using RolesService.DTO;
using RolesService.Interface;

namespace RolesService.Command
{
    public class PaginatedUserRoleCRUDCommand : IRequest<UserList>
    {
        public UserRoleDTO userRoleDTO { get; set; }
    }

    internal class PaginatedUserRoleHandler : IRequestHandler<PaginatedUserRoleCRUDCommand, UserList>
    {
        protected readonly IUserRole _userRole;
        public PaginatedUserRoleHandler(IUserRole userRole)
        {
            _userRole = userRole;
        }

        public async Task<UserList> Handle(PaginatedUserRoleCRUDCommand request, CancellationToken cancellationToken)
        {
            return await _userRole.PaginatedUserRoleCRUD(request.userRoleDTO);
        }
    }
}
