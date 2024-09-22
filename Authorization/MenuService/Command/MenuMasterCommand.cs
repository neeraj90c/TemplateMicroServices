using MenuService.DTO;
using MenuService.Interface;
using MediatR;

namespace MenuService.Command
{
    public class MenuMasterCommand : IRequest<MenuMasterList>
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
    internal class MenuMasterCommandHandler : IRequestHandler<MenuMasterCommand, MenuMasterList>
    {
        protected readonly IMenuContract _menuService;

        public MenuMasterCommandHandler(IMenuContract menuService)
        {
            _menuService = menuService;
        }
        public async Task<MenuMasterList> Handle(MenuMasterCommand request, CancellationToken cancellationToken)
        {
            return await _menuService.GetMenuForUser(request.UserId, request.ProjectId);
        }
    }
}
