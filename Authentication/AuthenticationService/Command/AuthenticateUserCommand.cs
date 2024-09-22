using AuthenticationService.DTO;
using AuthenticationService.Interface;
using MediatR;

namespace AuthenticationService.Command
{
    public class AuthenticateUserCommand : IRequest<UserDTO>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CompanyCode { get; set; }
    }

    internal class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, UserDTO>
    {
        protected readonly IUserContract _userService;

        public AuthenticateUserCommandHandler(IUserContract userService)
        {
            _userService = userService;
        }
        public async Task<UserDTO> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.Authenticate(request.CompanyCode, request.UserName, request.Password);
        }
    }
}
