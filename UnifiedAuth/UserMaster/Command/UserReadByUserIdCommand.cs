using MediatR;
using UserMaster.DTO;
using UserMaster.Interface;

namespace UserMaster.Command
{
    public class UserReadByUserIdCommand : IRequest<UserDTO>
    {
        public UserReadByUserIdRequestDTO reqDTO { get; set; }
    }
    internal class UserReadByUserIdHandler : IRequestHandler<UserReadByUserIdCommand, UserDTO>
    {
        protected readonly IUserMaster _userMaster;

        public UserReadByUserIdHandler(IUserMaster userMaster)
        {
            _userMaster = userMaster;
        }
        public async Task<UserDTO> Handle(UserReadByUserIdCommand request, CancellationToken cancellationToken)
        {
            return await _userMaster.ReadById(request.reqDTO);
        }
    }
}
