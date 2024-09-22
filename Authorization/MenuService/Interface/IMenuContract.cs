using MenuService.DTO;

namespace MenuService.Interface
{
    public interface IMenuContract
    {
        public Task<MenuMasterList> GetMenuForUser(int UserId, int ProjectId);
    }
}
