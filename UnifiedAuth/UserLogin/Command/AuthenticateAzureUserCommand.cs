using MediatR;
using UserLogin.DTO;
using UserLogin.Interface;

namespace UserLogin.Command
{
    public class AuthenticateAzureUserCommand : IRequest<UserDTO>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AzureUserId { get; set; }
        public string AzureEmailId { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
    internal class AuthenticateAzureUserCommandHandler : IRequestHandler<AuthenticateAzureUserCommand, UserDTO>
    {
        protected readonly IUserLogin _userService;

        public AuthenticateAzureUserCommandHandler(IUserLogin userService)
        {
            _userService = userService;
        }
        public async Task<UserDTO> Handle(AuthenticateAzureUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.AuthenticateAzure(request.FirstName, request.LastName, request.AzureUserId, request.AzureEmailId, request.ExpiresOn);
        }
    }
}
