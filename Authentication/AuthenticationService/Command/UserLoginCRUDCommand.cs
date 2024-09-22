using AuthenticationService.DTO;
using AuthenticationService.Interface;
using MediatR;

namespace AuthenticationService.Command
{
    public class UserLoginCRUDCommand : IRequest<UserList>
    {
        public UserCredDTO UserCredDTO { get; set; }
    }

    internal class UserLoginCRUDHandler : IRequestHandler<UserLoginCRUDCommand, UserList>
    {
        private readonly IUserMaster _user;

        public UserLoginCRUDHandler(IUserMaster user)
        {
            _user = user;
        }

        public async Task<UserList> Handle(UserLoginCRUDCommand request, CancellationToken cancellationToken)
        {
            return await _user.CreateUserCredentials(request.UserCredDTO);
        }
    }
}
