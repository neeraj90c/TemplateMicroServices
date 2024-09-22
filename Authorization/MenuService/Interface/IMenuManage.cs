using MenuService.DTO;

namespace MenuService.Interface
{
    public interface IMenuManage
    {
        public Task<MenuManageList> ManageMenu(MenuManageDTO menuManageDTO);
        public Task<AdminDashboardList> AdminDashboardGet(int actionUser);
    }
}
