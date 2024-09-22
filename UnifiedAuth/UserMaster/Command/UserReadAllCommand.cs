using MediatR;
using UserMaster.DTO;
using UserMaster.Interface;

namespace UserMaster.Command
{
    public class UserReadAllCommand : IRequest<UserList>
    {
    }
    internal class UserReadAllHandler : IRequestHandler<UserReadAllCommand, UserList>
    {
        protected readonly IUserMaster _userMaster;

        public UserReadAllHandler(IUserMaster userMaster)
        {
            _userMaster = userMaster;
        }
        public async Task<UserList> Handle(UserReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _userMaster.ReadAll();
        }
    }
}
