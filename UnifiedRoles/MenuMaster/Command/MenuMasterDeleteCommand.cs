using MediatR;
using MenuMaster.DTO;
using MenuMaster.Interface;

namespace MenuMaster.Command
{
    public class MenuMasterDeleteCommand : IRequest
    {
        public MenuMasterDeleteRequestDTO reqDTO { get; set; }
    }
    internal class MenuMasterDeleteHandler : IRequestHandler<MenuMasterDeleteCommand>
    {
        protected readonly IMenuMaster _menuMaster;

        public MenuMasterDeleteHandler(IMenuMaster menuMaster)
        {
            _menuMaster = menuMaster;
        }
        public async Task Handle(MenuMasterDeleteCommand request, CancellationToken cancellationToken)
        {
            await _menuMaster.Delete(request.reqDTO);
        }
    }
}
