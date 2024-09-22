using MediatR;
using RolesService.DTO;
using RolesService.Interface;

namespace RolesService.Command
{
    public class UserRoleCRUDCommand : IRequest<UserList>
    {
        public UserRoleDTO userRoleDTO { get; set; }
    }

    internal class UserRoleHandler : IRequestHandler<UserRoleCRUDCommand, UserList>
    {
        protected readonly IUserRole _userRole;
        public UserRoleHandler(IUserRole userRole)
        {
            _userRole = userRole;
        }

        public async Task<UserList> Handle(UserRoleCRUDCommand request, CancellationToken cancellationToken)
        {
            return await _userRole.UserRoleCRUD(request.userRoleDTO);
        }
    }
}
