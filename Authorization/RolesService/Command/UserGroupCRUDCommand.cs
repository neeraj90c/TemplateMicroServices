using MediatR;
using RolesService.DTO;
using RolesService.Interface;

namespace RolesService.Command
{
    public class UserGroupCRUDCommand : IRequest<UserGroupList>
    {
        public UserGroupDTO userGroupDTO { get; set; }
    }
    internal class UserGroupHandler : IRequestHandler<UserGroupCRUDCommand, UserGroupList>
    {
        protected readonly IUserGroup _userGroup;

        public UserGroupHandler(IUserGroup userGroup)
        {
            _userGroup = userGroup;
        }
        public async Task<UserGroupList> Handle(UserGroupCRUDCommand request, CancellationToken cancellationToken)
        {
            return await _userGroup.ManageUserGroup(request.userGroupDTO);
        }
    }
}
