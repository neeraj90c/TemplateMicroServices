using Common.Service;
using Microsoft.Extensions.Options;
using RolesService.DTO;
using RolesService.Interface;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Common.DTO;

namespace RolesService.Service
{
    public class RolesService : DABase, IRole
    {
        private const string SP_RolesMaster_CRUD = "RolesMaster_CRUD";
        private const string SP_Roles_GetDictionary = "Roles_GetDictionary";

        private ILogger<RolesService> _logger;
        public RolesService(IOptions<ConnectionSettings> connectionSettings, ILogger<RolesService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }

        public async Task<RolesList> ManageRoles(RolesDTO rolesDTO)
        {
            RolesList response = new RolesList();

            _logger.LogInformation($"Started fetching all Roles by Id:{rolesDTO.RoleId}");
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    response.Roles = await connection.QueryAsync<RolesDTO>(SP_RolesMaster_CRUD, new
                    {
                        ProjectId = rolesDTO.ProjectId,
                        RoleId = rolesDTO.RoleId,
                        RoleName = rolesDTO.RoleName,
                        RoleCode = rolesDTO.RoleCode,
                        RoleDesc = rolesDTO.RoleDesc,
                        ActionUser = rolesDTO.ActionUser,
                        IsActive = rolesDTO.IsActive,
                        IsDeleted = rolesDTO.IsDeleted,
                        PageSize = rolesDTO.PageSize,
                        PageNo = rolesDTO.PageNo,

                    }, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured while executing task On Roles");
                throw new Exception(ex.Message);
            }
            return response;

        }
        
        public async Task<DropDownList> GetRolesDictionary()
        {
            DropDownList response = new DropDownList();

            _logger.LogInformation($"Started fetching all Roles Dictionary");
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    response.dropDownList = await connection.QueryAsync<DropDownDTO>(SP_Roles_GetDictionary, new
                    {
                    }, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured while executing task On Roles");
                throw new Exception(ex.Message);
            }
            return response;

        }

    }
}
