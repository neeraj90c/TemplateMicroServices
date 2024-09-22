using MediatR;
using UserLogin.DTO;
using UserLogin.Interface;

namespace UserLogin.Command
{
    public class UserLoginUpdateCommand : IRequest<UserLoginDTO>
    {
        public UserLoginUpdateRequestDTO reqDTO { get; set; }
    }
    internal class UserLoginUpdateHandler : IRequestHandler<UserLoginUpdateCommand, UserLoginDTO>
    {
        protected readonly IUserLogin _userLogin;

        public UserLoginUpdateHandler(IUserLogin userLogin)
        {
            _userLogin = userLogin;
        }
        public async Task<UserLoginDTO> Handle(UserLoginUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _userLogin.Update(request.reqDTO);
        }
    }
}
