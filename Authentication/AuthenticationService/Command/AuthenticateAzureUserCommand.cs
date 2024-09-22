using AuthenticationService.DTO;
using AuthenticationService.Interface;
using MediatR;

namespace AuthenticationService.Command
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
        protected readonly IUserContract _userService;

        public AuthenticateAzureUserCommandHandler(IUserContract userService)
        {
            _userService = userService;
        }
        public async Task<UserDTO> Handle(AuthenticateAzureUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.AuthenticateAzure(request.FirstName, request.LastName, request.AzureUserId, request.AzureEmailId, request.ExpiresOn);
        }
    }
}
