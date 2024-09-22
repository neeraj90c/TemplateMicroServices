using Common.Service;
using MenuService.DTO;
using MenuService.Interface;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace MenuService.Service
{
    public class MenuMasterService : DABase, IMenuContract, IMenuManage
    {
        private const string SP_UserRolesByUserId = "UserRolesByUserId";
        private const string SP_MenuMaster_CRUD = "MenuMaster_CRUD";
        private const string SP_AdminDashboard_GetDetails = "AdminDashboard_GetDetails";

        private ILogger<MenuMasterService> _logger;
        public MenuMasterService(IOptions<ConnectionSettings> connectionSettings, ILogger<MenuMasterService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }

        public async Task<MenuMasterList> GetMenuForUser(int UserId, int ProjectId)
        {
            MenuMasterList menuMasterInfo = new MenuMasterList();
            //IList<MenuMasterDTO> menuMasterInfo = null;
            var menuList = new object();
            _logger.LogInformation($"Started menu fetch for user id: {UserId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                menuMasterInfo.Items = await connection.QueryAsync<MenuMasterDTO>(SP_UserRolesByUserId, new
                {
                    UserId = UserId,
                    ProjectId = ProjectId,

                }, commandType: CommandType.StoredProcedure);

            }
            return menuMasterInfo;
        }

        public async Task<MenuManageList> ManageMenu(MenuManageDTO menuManageDTO)
        {
            MenuManageList response = new MenuManageList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                response.Menus = await connection.QueryAsync<MenuManageDTO>(SP_MenuMaster_CRUD, new
                {

                    MenuId = menuManageDTO.MenuId,
                    ProjectId = menuManageDTO.ProjectId,
                    MenuName = menuManageDTO.MenuName,
                    MenuCode = menuManageDTO.MenuCode,
                    MenuDesc = menuManageDTO.MenuDesc,
                    DisplayOrder = menuManageDTO.DisplayOrder,
                    ParentMenuId = menuManageDTO.ParentMenuId,
                    DefaultChildMenuId = menuManageDTO.DefaultChildMenuId,
                    MenuIconUrl = menuManageDTO.MenuIconUrl,
                    TemplatePath = menuManageDTO.TemplatePath,
                    IsActive = menuManageDTO.IsActive,
                    IsDeleted = menuManageDTO.IsDeleted,
                    ActionUser = menuManageDTO.ActionUser

                }, commandType: CommandType.StoredProcedure);

            }
            return response;
        }

        public async Task<AdminDashboardList> AdminDashboardGet(int ActionUser)
        {
            AdminDashboardList response = new AdminDashboardList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                using (var multi = await connection.QueryMultipleAsync(SP_AdminDashboard_GetDetails, commandType: CommandType.StoredProcedure))
                {
                    response.DashboardList = await multi.ReadAsync<DashboardHeaderDTO>();
                    response.WorkCenterList = await multi.ReadAsync<WorkCenterForDashboardDTO>();
                    response.PerformanceList = await multi.ReadAsync<UserPerformanceForDashboardDTO>();
                    response.ActivePagesList = await multi.ReadAsync<ActivePagesForDashboardDTO>();
                    response.ActiveRolesList = await multi.ReadAsync<RoleDetailsForDashboardDTO>();
                }
            }

            return response;
        }


    }
}
