using AuthenticationService.DTO;
using AuthenticationService.Interface;
using MediatR;

namespace AuthenticationService.Command
{
    public class UserCRUDCommand : IRequest<UserList>
    {
        public UserMasterDTO userMasterDTO { get; set; }
    }

    internal class UserHandler : IRequestHandler<UserCRUDCommand, UserList>
    {
        protected readonly IUserMaster _user;
        public UserHandler(IUserMaster user)
        {
            _user = user;
        }

        public async Task<UserList> Handle(UserCRUDCommand request, CancellationToken cancellationToken)
        {
            return await _user.UserCRUD(request.userMasterDTO);
        }

    }
}
