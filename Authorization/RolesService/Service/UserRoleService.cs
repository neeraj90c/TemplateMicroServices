using Common.DTO;
using Common.Service;
using Microsoft.Extensions.Options;
using RolesService.DTO;
using RolesService.Interface;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Drawing.Printing;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RolesService.Service
{
    public class UserRoleService : DABase, IUserRole
    {
        APISettings _settings;
        ConnectionSettings _connectionSettings;
        private ILogger<UserRoleService> _logger;

        private const string SP_UserRole_CRUD = "dbo.UserRole_CRUD";
        private const string SP_PaginatedUserRole_CRUD = "dbo.PaginatedUserRole_CRUD";

        public UserRoleService(IOptions<ConnectionSettings> connectionSettings, ILogger<UserRoleService> logger, IOptions<APISettings> settings) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
            _settings = settings.Value;
            _connectionSettings = connectionSettings.Value;
        }

        public async Task<UserList> UserRoleCRUD(UserRoleDTO userRoleDTO)
        {
            UserList response = new UserList();

            _logger.LogInformation($"Started Executing UserRole Mapping and retrieving role assigned to user: {userRoleDTO.UserRoleId}");
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                response.Users = await connection.QueryAsync<UserMasterDTO>(SP_UserRole_CRUD, new
                {

                    UserRoleId = userRoleDTO.UserRoleId,
                    ProjectId = userRoleDTO.ProjectId,
                    UserId = userRoleDTO.UserId,
                    RoleId = userRoleDTO.RoleId,
                    ActionUser = userRoleDTO.ActionUser,
                    IsActive = userRoleDTO.IsActive,
                    IsDeleted = userRoleDTO.IsDeleted

                }, commandType: CommandType.StoredProcedure);
            }


            return response;

        }
        public async Task<UserList> PaginatedUserRoleCRUD(UserRoleDTO userRoleDTO)
        {
            UserList response = new UserList();

            _logger.LogInformation($"Started Executing UserRole Mapping and retrieving role assigned to user: {userRoleDTO.UserRoleId}");
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                response.Users = await connection.QueryAsync<UserMasterDTO>(SP_PaginatedUserRole_CRUD, new
                {

                    UserRoleId = userRoleDTO.UserRoleId,
                    ProjectId = userRoleDTO.ProjectId,
                    UserId = userRoleDTO.UserId,
                    RoleId = userRoleDTO.RoleId,
                    ActionUser = userRoleDTO.ActionUser,
                    IsActive = userRoleDTO.IsActive,
                    IsDeleted = userRoleDTO.IsDeleted,
                    PageSize = userRoleDTO.PageSize,
                    PageNo = userRoleDTO.PageNo,

                }, commandType: CommandType.StoredProcedure);
            }


            return response;

        }
    }
}
