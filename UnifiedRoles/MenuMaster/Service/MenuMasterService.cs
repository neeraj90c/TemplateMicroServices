using Common.Service;
using MenuMaster.Interface;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using MenuMaster.DTO;
using Dapper;
using Microsoft.AspNetCore.Routing.Template;

namespace MenuMaster.Service
{
    public class MenuMasterService : DABase, IMenuMaster
    {
        private const string SP_MenuMaster_Create = "MenuMaster_Create";
        private const string SP_MenuMaster_Delete = "MenuMaster_Delete";
        private const string SP_MenuMaster_ReadAll = "MenuMaster_ReadAll";
        private const string SP_MenuMaster_ReadById = "MenuMaster_ReadById";
        private const string SP_MenuMaster_ReadByProjectId = "MenuMaster_ReadByProjectId";
        private const string SP_MenuMaster_Update = "MenuMaster_Update";
        private ILogger<MenuMasterService> _logger;
        public MenuMasterService(IOptions<ConnectionSettings> connectionSettings, ILogger<MenuMasterService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<MenuMasterDTO> Create(MenuMasterCreateRequestDTO reqDTO)
        {

            MenuMasterDTO retObj = null;
            _logger.LogInformation($"Started Menu Master Create {reqDTO.MenuName} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<MenuMasterDTO>(SP_MenuMaster_Create, new
                {
                    ProjectId = reqDTO.ProjectId,
                    MenuName = reqDTO.MenuName,
                    MenuCode = reqDTO.MenuCode,
                    MenuDesc = reqDTO.MenuDesc,
                    DisplayOrder = reqDTO.DisplayOrder,
                    ParentMenuId = reqDTO.ParentMenuId,
                    DefaultChildMenuId = reqDTO.DefaultChildMenuId,
                    MenuIconUrl = reqDTO.MenuIconUrl,
                    TemplatePath = reqDTO.TemplatePath,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<MenuMasterDTO> Update(MenuMasterUpdateRequestDTO reqDTO)
        {

            MenuMasterDTO retObj = null;
            _logger.LogInformation($"Started Menu Master Update {reqDTO.MenuId}  for Menu: {reqDTO.MenuName}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<MenuMasterDTO>(SP_MenuMaster_Update, new
                {
                    MenuId = reqDTO.MenuId,
                    ProjectId = reqDTO.ProjectId,
                    MenuName = reqDTO.MenuName,
                    MenuCode = reqDTO.MenuCode,
                    MenuDesc = reqDTO.MenuDesc,
                    DisplayOrder = reqDTO.DisplayOrder,
                    ParentMenuId = reqDTO.ParentMenuId,
                    DefaultChildMenuId = reqDTO.DefaultChildMenuId,
                    MenuIconUrl = reqDTO.MenuIconUrl,
                    TemplatePath = reqDTO.TemplatePath,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(MenuMasterDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started Menu Master Delete {reqDTO.MenuId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_MenuMaster_Delete, new
                {
                    MenuId = reqDTO.MenuId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
        }
        public async Task<MenuMasterDTO> ReadById(MenuMasterReadByIdRequestDTO reqDTO)
        {

            MenuMasterDTO retObj = null;
            _logger.LogInformation($"Started Menu Master ReadById {reqDTO.MenuId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<MenuMasterDTO>(SP_MenuMaster_ReadById, new
                {
                    MenuId = reqDTO.MenuId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<MenuMasterList> ReadAll()
        {

            MenuMasterList retObj = new MenuMasterList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<MenuMasterDTO>(SP_MenuMaster_ReadAll, new
                {
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<MenuMasterList> ReadByProjectId(MenuMasterReadByProjectIdRequestDTO reqDTO)
        {

            MenuMasterList retObj = new MenuMasterList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<MenuMasterDTO>(SP_MenuMaster_ReadByProjectId, new
                {
                    ProjectId = reqDTO.ProjectId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
    }
}
