using AuthenticationService.DTO;
using AuthenticationService.Interface;
using MediatR;

namespace AuthenticationService.Command
{
    public class UserStatusUpdateCommand : IRequest<UserMasterDTO>
    {
        public UserMasterDTO userMasterDTO { get; set; }
    }

    internal class UserStatusUpdateHandler : IRequestHandler<UserStatusUpdateCommand, UserMasterDTO>
    {
        protected readonly IUserMaster _user;
        public UserStatusUpdateHandler(IUserMaster user)
        {
            _user = user;
        }

        public async Task<UserMasterDTO> Handle(UserStatusUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _user.UserStatusUpdate(request.userMasterDTO);
        }

    }
}
