using MediatR;
using UserMaster.DTO;
using UserMaster.Interface;

namespace UserMaster.Command
{
    public class UserReadAllPaginatedCommand : IRequest<UserList>
    {
        public UserReadAllPaginatedRequestDTO reqDTO { get; set; }
    }
    internal class UserReadAllPaginatedHandler : IRequestHandler<UserReadAllPaginatedCommand, UserList>
    {
        protected readonly IUserMaster _userMaster;

        public UserReadAllPaginatedHandler(IUserMaster userMaster)
        {
            _userMaster = userMaster;
        }
        public async Task<UserList> Handle(UserReadAllPaginatedCommand request, CancellationToken cancellationToken)
        {
            return await _userMaster.ReadAllPaginated(request.reqDTO);
        }
    }
}
