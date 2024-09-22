using MediatR;
using UserLogin.DTO;
using UserLogin.Interface;

namespace UserLogin.Command
{
    public class UserLoginDeleteCommand : IRequest
    {
        public UserLoginDeleteRequestDTO reqDTO { get; set; }
    }
    internal class UserLoginDeleteHandler : IRequestHandler<UserLoginDeleteCommand>
    {
        protected readonly IUserLogin _userLogin;

        public UserLoginDeleteHandler(IUserLogin userLogin)
        {
            _userLogin = userLogin;
        }
        public async Task Handle(UserLoginDeleteCommand request, CancellationToken cancellationToken)
        {
            await _userLogin.Delete(request.reqDTO);
        }
    }
}
