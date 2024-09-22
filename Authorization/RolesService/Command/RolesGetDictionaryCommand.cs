using Common.DTO;
using MediatR;
using RolesService.Interface;

namespace RolesService.Command
{
    public class RolesGetDictionaryCommand : IRequest<DropDownList>
    {
    }
    internal class RolesGetDictionaryHandler : IRequestHandler<RolesGetDictionaryCommand, DropDownList>
    {
        protected readonly IRole _role;

        public RolesGetDictionaryHandler(IRole role)
        {
            _role = role;
        }
        public async Task<DropDownList> Handle(RolesGetDictionaryCommand request, CancellationToken cancellationToken)
        {
            return await _role.GetRolesDictionary();
        }
    }
}
