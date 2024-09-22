using MenuService.DTO;
using MenuService.Interface;
using MediatR;

namespace MenuService.Command
{
    public class MenuManageCRUDCommand : IRequest<MenuManageList>
    {
        public MenuManageDTO menuManageDTO { get; set; }
    }
    internal class MenuMasterCRUDHandler : IRequestHandler<MenuManageCRUDCommand, MenuManageList>
    {
        protected readonly IMenuManage _menuMasterCrud;

        public MenuMasterCRUDHandler(IMenuManage menuMasterCrud)
        {
            _menuMasterCrud = menuMasterCrud;
        }
        public async Task<MenuManageList> Handle(MenuManageCRUDCommand request, CancellationToken cancellationToken)
        {
            return await _menuMasterCrud.ManageMenu(request.menuManageDTO);
        }
    }
}
