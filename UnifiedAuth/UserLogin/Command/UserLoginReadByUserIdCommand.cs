using MediatR;
using UserLogin.DTO;
using UserLogin.Interface;

namespace UserLogin.Command
{
    public class UserLoginReadByUserIdCommand : IRequest<UserLoginDTO>
    {
        public UserLoginReadByUserIdRequestDTO reqDTO { get; set; }
    }
    internal class UserLoginReadByUserIdHandler : IRequestHandler<UserLoginReadByUserIdCommand, UserLoginDTO>
    {
        protected readonly IUserLogin _userLogin;

        public UserLoginReadByUserIdHandler(IUserLogin userLogin)
        {
            _userLogin = userLogin;
        }
        public async Task<UserLoginDTO> Handle(UserLoginReadByUserIdCommand request, CancellationToken cancellationToken)
        {
            return await _userLogin.ReadByUserId(request.reqDTO);
        }
    }
}
