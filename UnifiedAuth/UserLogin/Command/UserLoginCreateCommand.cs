using MediatR;
using UserLogin.DTO;
using UserLogin.Interface;

namespace UserLogin.Command
{
    public class UserLoginCreateCommand : IRequest<UserLoginDTO>
    {
        public UserLoginCreateRequestDTO reqDTO { get; set; }
    }
    internal class UserLoginCreateHandler : IRequestHandler<UserLoginCreateCommand, UserLoginDTO>
    {
        protected readonly IUserLogin _userLogin;

        public UserLoginCreateHandler(IUserLogin userLogin)
        {
            _userLogin = userLogin;
        }
        public async Task<UserLoginDTO> Handle(UserLoginCreateCommand request, CancellationToken cancellationToken)
        {
            return await _userLogin.Create(request.reqDTO);
        }
    }
}
