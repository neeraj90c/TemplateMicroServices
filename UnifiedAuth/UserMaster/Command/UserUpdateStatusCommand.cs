using MediatR;
using UserMaster.DTO;
using UserMaster.Interface;

namespace UserMaster.Command
{
    public class UserUpdateStatusCommand : IRequest<UserDTO>
    {
        public UserUpdateStatusRequestDTO reqDTO { get; set; }
    }
    internal class UserUpdateStatusHandler : IRequestHandler<UserUpdateStatusCommand, UserDTO>
    {
        protected readonly IUserMaster _userMaster;

        public UserUpdateStatusHandler(IUserMaster userMaster)
        {
            _userMaster = userMaster;
        }
        public async Task<UserDTO> Handle(UserUpdateStatusCommand request, CancellationToken cancellationToken)
        {
            return await _userMaster.UpdateStatus(request.reqDTO);
        }
    }
}
