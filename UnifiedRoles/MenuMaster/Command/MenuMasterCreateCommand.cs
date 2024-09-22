using MediatR;
using MenuMaster.DTO;
using MenuMaster.Interface;

namespace MenuMaster.Command
{
    public class MenuMasterCreateCommand : IRequest<MenuMasterDTO>
    {
        public MenuMasterCreateRequestDTO reqDTO { get; set; }
    }
    internal class MenuMasterCreateHandler : IRequestHandler<MenuMasterCreateCommand, MenuMasterDTO>
    {
        protected readonly IMenuMaster _menuMaster;

        public MenuMasterCreateHandler(IMenuMaster menuMaster)
        {
            _menuMaster = menuMaster;
        }
        public async Task<MenuMasterDTO> Handle(MenuMasterCreateCommand request, CancellationToken cancellationToken)
        {
            return await _menuMaster.Create(request.reqDTO);
        }
    }
}
