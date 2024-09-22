using AuthenticationService.Interface;
using Common.DTO;
using MediatR;

namespace AuthenticationService.Command
{
    public class GetAllUserListCommand : IRequest<DropDownList>
    {
    }
    internal class GetAllUserListCommandHandler : IRequestHandler<GetAllUserListCommand, DropDownList>
    {
        protected readonly IUserMaster _userMaster;

        public GetAllUserListCommandHandler(IUserMaster userMaster)
        {
            _userMaster = userMaster;
        }
        public async Task<DropDownList> Handle(GetAllUserListCommand request, CancellationToken cancellationToken)
        {
            return await _userMaster.GetAllUserList();
        }
    }
}
