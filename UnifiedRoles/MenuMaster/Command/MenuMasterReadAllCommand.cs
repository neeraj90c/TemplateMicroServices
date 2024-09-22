using MediatR;
using MenuMaster.DTO;
using MenuMaster.Interface;

namespace MenuMaster.Command
{
    public class MenuMasterReadAllCommand : IRequest<MenuMasterList>
    {
    }
    internal class MenuMasterReadAllHandler : IRequestHandler<MenuMasterReadAllCommand, MenuMasterList>
    {
        protected readonly IMenuMaster _menuMaster;

        public MenuMasterReadAllHandler(IMenuMaster menuMaster)
        {
            _menuMaster = menuMaster;
        }
        public async Task<MenuMasterList> Handle(MenuMasterReadAllCommand request, CancellationToken cancellationToken)
        {
            return await _menuMaster.ReadAll();
        }
    }
}
