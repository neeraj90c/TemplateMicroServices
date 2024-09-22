using MediatR;
using RolesService.DTO;
using RolesService.Interface;

namespace RolesService.Command
{
    public class UserGroupCRUDPaginatedCommand : IRequest<UserGroupList>
    {
        public UserGroupDTO userGroupDTO { get; set; }
    }
    internal class UserGroupCRUDPaginatedHandler : IRequestHandler<UserGroupCRUDPaginatedCommand, UserGroupList>
    {
        protected readonly IUserGroup _userGroup;

        public UserGroupCRUDPaginatedHandler(IUserGroup userGroup)
        {
            _userGroup = userGroup;
        }
        public async Task<UserGroupList> Handle(UserGroupCRUDPaginatedCommand request, CancellationToken cancellationToken)
        {
            return await _userGroup.ManageUserGroupPaginated(request.userGroupDTO);
        }
    }
}
