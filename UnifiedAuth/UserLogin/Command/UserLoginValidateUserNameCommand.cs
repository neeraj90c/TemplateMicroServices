using MediatR;
using UserLogin.DTO;
using UserLogin.Interface;

namespace UserLogin.Command
{
    public class UserLoginValidateUserNameCommand : IRequest<ValidationResponse>
    {
        public UserLoginValidateUserNameRequestDTO reqDTO { get; set; }
    }
    internal class UserLoginValidateUserNameHandler : IRequestHandler<UserLoginValidateUserNameCommand, ValidationResponse>
    {
        protected readonly IUserLogin _userLogin;

        public UserLoginValidateUserNameHandler(IUserLogin userLogin)
        {
            _userLogin = userLogin;
        }
        public async Task<ValidationResponse> Handle(UserLoginValidateUserNameCommand request, CancellationToken cancellationToken)
        {
            return await _userLogin.ValidateUserName(request.reqDTO);
        }
    }
}
