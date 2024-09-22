using MediatR;
using RolesService.DTO;
using RolesService.Interface;

namespace RolesService.Command
{
    public class SubRolesCommand : IRequest<SubRolesList>
    {
        public SubRolesDTO subRolesDTO { get; set; }
    }
    internal class SubRolesHandler : IRequestHandler<SubRolesCommand, SubRolesList>
    {
        protected readonly ISubRole _subRole;

        public SubRolesHandler(ISubRole subRole)
        {
            _subRole = subRole;
        }
        public async Task<SubRolesList> Handle(SubRolesCommand request, CancellationToken cancellationToken)
        {
            return await _subRole.SubRolesMapping(request.subRolesDTO);
        }
    }
}
