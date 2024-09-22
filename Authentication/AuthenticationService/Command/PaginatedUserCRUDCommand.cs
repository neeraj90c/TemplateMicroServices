using AuthenticationService.DTO;
using AuthenticationService.Interface;
using MediatR;

namespace AuthenticationService.Command
{
    public class PaginatedUserCRUDCommand : IRequest<UserList>
    {
        public UserMasterDTO userMasterDTO { get; set; }
    }

    internal class PaginatedUserCRUDHandler : IRequestHandler<PaginatedUserCRUDCommand, UserList>
    {
        protected readonly IUserMaster _user;
        public PaginatedUserCRUDHandler(IUserMaster user)
        {
            _user = user;
        }

        public async Task<UserList> Handle(PaginatedUserCRUDCommand request, CancellationToken cancellationToken)
        {
            return await _user.PaginatedUserCRUD(request.userMasterDTO);
        }

    }
}
