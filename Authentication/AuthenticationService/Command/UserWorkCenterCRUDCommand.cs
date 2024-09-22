using AuthenticationService.DTO;
using AuthenticationService.Interface;
using MediatR;

namespace AuthenticationService.Command
{
    public class UserWorkCenterCRUDCommand : IRequest<UserWorkCenterList>
    {
        public UserWorkCenterDTO userWorkCenterDTO { get; set; }
    }

    internal class UserWorkCenterHandler : IRequestHandler<UserWorkCenterCRUDCommand, UserWorkCenterList>
    {
        protected readonly IUserMaster _userWorkCenter;
        public UserWorkCenterHandler(IUserMaster userWorkCenter)
        {
            _userWorkCenter = userWorkCenter;
        }

        public async Task<UserWorkCenterList> Handle(UserWorkCenterCRUDCommand request, CancellationToken cancellationToken)
        {
            return await _userWorkCenter.UserWorkCenterCRUD(request.userWorkCenterDTO);
        }
    }
}
