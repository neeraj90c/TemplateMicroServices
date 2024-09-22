using MediatR;
using MenuMaster.DTO;
using MenuMaster.Interface;

namespace MenuMaster.Command
{
    public class MenuMasterReadByProjectIdCommand : IRequest<MenuMasterList>
    {
        public MenuMasterReadByProjectIdRequestDTO reqDTO { get; set; }
    }
    internal class MenuMasterReadByProjectIdHandler : IRequestHandler<MenuMasterReadByProjectIdCommand, MenuMasterList>
    {
        protected readonly IMenuMaster _menuMaster;

        public MenuMasterReadByProjectIdHandler(IMenuMaster menuMaster)
        {
            _menuMaster = menuMaster;
        }
        public async Task<MenuMasterList> Handle(MenuMasterReadByProjectIdCommand request, CancellationToken cancellationToken)
        {
            return await _menuMaster.ReadByProjectId(request.reqDTO);
        }
    }
}
