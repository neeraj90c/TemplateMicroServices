using MediatR;
using MenuMaster.DTO;
using MenuMaster.Interface;

namespace MenuMaster.Command
{
    public class MenuMasterReadByIdCommand : IRequest<MenuMasterDTO>
    {
        public MenuMasterReadByIdRequestDTO reqDTO { get; set; }
    }
    internal class MenuMasterReadByIdHandler : IRequestHandler<MenuMasterReadByIdCommand, MenuMasterDTO>
    {
        protected readonly IMenuMaster _menuMaster;

        public MenuMasterReadByIdHandler(IMenuMaster menuMaster)
        {
            _menuMaster = menuMaster;
        }
        public async Task<MenuMasterDTO> Handle(MenuMasterReadByIdCommand request, CancellationToken cancellationToken)
        {
            return await _menuMaster.ReadById(request.reqDTO);
        }
    }
}
