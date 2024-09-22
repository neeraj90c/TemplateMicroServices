using MediatR;
using UserMaster.DTO;
using UserMaster.Interface;

namespace UserMaster.Command
{
    public class UserUpdateCommand : IRequest<UserDTO>
    {
        public UserUpdateRequestDTO reqDTO { get; set; }
    }
    internal class UserUpdateHandler : IRequestHandler<UserUpdateCommand, UserDTO>
    {
        protected readonly IUserMaster _userMaster;

        public UserUpdateHandler(IUserMaster userMaster)
        {
            _userMaster = userMaster;
        }
        public async Task<UserDTO> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _userMaster.Update(request.reqDTO);
        }
    }
}
