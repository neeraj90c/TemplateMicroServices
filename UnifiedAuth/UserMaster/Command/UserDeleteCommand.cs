using MediatR;
using UserMaster.DTO;
using UserMaster.Interface;

namespace UserMaster.Command
{
    public class UserDeleteCommand : IRequest
    {
        public UserDeleteRequestDTO reqDTO { get; set; }
    }
    internal class UserDeleteHandler : IRequestHandler<UserDeleteCommand>
    {
        protected readonly IUserMaster _userMaster;

        public UserDeleteHandler(IUserMaster userMaster)
        {
            _userMaster = userMaster;
        }
        public async Task Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            await _userMaster.Delete(request.reqDTO);
        }
    }
}
