using AuthenticationService.DTO;
using AuthenticationService.Interface;
using MediatR;

namespace AuthenticationService.Command
{
    public class UserDashboardCommand : IRequest<UserDashboardList>
    {
        public UserDashboardDTO userDashboardDTO { get; set; }
    }
    internal class UserDashboardHandler : IRequestHandler<UserDashboardCommand, UserDashboardList>
    {
        protected readonly IUserMaster _user;

        public UserDashboardHandler(IUserMaster user)
        {
            _user = user;
        }

        public async Task<UserDashboardList> Handle(UserDashboardCommand request, CancellationToken cancellationToken)
        {
            return await _user.UserDashboardGet(request.userDashboardDTO);
        }
    }
}
