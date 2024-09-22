using MediatR;
using UserMaster.DTO;
using UserMaster.Interface;

namespace UserMaster.Command
{
    public class UserCreateCommand : IRequest<UserDTO>
    {
        public UserCreateRequestDTO reqDTO { get; set; }
    }
    internal class UserCreateHandler : IRequestHandler<UserCreateCommand, UserDTO>
    {
        protected readonly IUserMaster _userMaster;

        public UserCreateHandler(IUserMaster userMaster)
        {
            _userMaster = userMaster;
        }
        public async Task<UserDTO> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            return await _userMaster.Create(request.reqDTO);
        }
    }
}
