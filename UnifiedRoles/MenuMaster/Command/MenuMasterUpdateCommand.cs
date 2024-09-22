using MediatR;
using MenuMaster.DTO;
using MenuMaster.Interface;

namespace MenuMaster.Command
{
    public class MenuMasterUpdateCommand : IRequest<MenuMasterDTO>
    {
        public MenuMasterUpdateRequestDTO reqDTO { get; set; }
    }
    internal class MenuMasterUpdateHandler : IRequestHandler<MenuMasterUpdateCommand, MenuMasterDTO>
    {
        protected readonly IMenuMaster _menuMaster;

        public MenuMasterUpdateHandler(IMenuMaster menuMaster)
        {
            _menuMaster = menuMaster;
        }
        public async Task<MenuMasterDTO> Handle(MenuMasterUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _menuMaster.Update(request.reqDTO);
        }
    }
}
