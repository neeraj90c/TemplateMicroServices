using MenuService.DTO;
using MenuService.Interface;
using MediatR;

namespace MenuService.Command
{
    public class AdminDashboardCommand : IRequest<AdminDashboardList>
    {
        public int ActionUser { get; set; }
    }
    internal class AdminDashboardHandler : IRequestHandler<AdminDashboardCommand, AdminDashboardList>
    {
        protected readonly IMenuManage _user;

        public AdminDashboardHandler(IMenuManage user)
        {
            _user = user;
        }

        public async Task<AdminDashboardList> Handle(AdminDashboardCommand request, CancellationToken cancellationToken)
        {
            return await _user.AdminDashboardGet(request.ActionUser);
        }

    }
}
