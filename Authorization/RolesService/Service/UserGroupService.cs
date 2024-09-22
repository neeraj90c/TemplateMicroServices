using Common.Service;
using Microsoft.Extensions.Options;
using RolesService.DTO;
using RolesService.Interface;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace RolesService.Service
{
    public class UserGroupService : DABase, IUserGroup
    {
        private const string SP_UserGroupMaster_CRUD = "UserGroupMaster_CRUD";
        private const string SP_UserGroupMaster_CRUDPaginated = "UserGroupMaster_CRUDPaginated";
        private ILogger<UserGroupService> _logger;
        public UserGroupService(IOptions<ConnectionSettings> connectionSettings, ILogger<UserGroupService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }

        public async Task<UserGroupList> ManageUserGroup(UserGroupDTO userGroupDTO)
        {
            UserGroupList response = new UserGroupList();

            _logger.LogInformation($"Started fetching all Groups by Id: {userGroupDTO.GroupId} ");

            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                response.Groups = await connection.QueryAsync<UserGroupDTO>(SP_UserGroupMaster_CRUD, new
                {
                    GroupId = userGroupDTO.GroupId,
                    GroupName = userGroupDTO.GroupName,
                    GroupCode = userGroupDTO.GroupCode,
                    GroupDesc = userGroupDTO.GroupDesc,
                    ActionUser = userGroupDTO.ActionUser,
                    IsActive = userGroupDTO.IsActive,
                    IsDeleted = userGroupDTO.IsDeleted,

                }, commandType: CommandType.StoredProcedure);

            }
            return response;
        }
        public async Task<UserGroupList> ManageUserGroupPaginated(UserGroupDTO userGroupDTO)
        {
            UserGroupList response = new UserGroupList();

            _logger.LogInformation($"Started fetching all Groups by Id: {userGroupDTO.GroupId} ");

            using (SqlConnection connection = new SqlConnection(base.ConnectionString))
            {
                response.Groups = await connection.QueryAsync<UserGroupDTO>(SP_UserGroupMaster_CRUDPaginated, new
                {
                    GroupId = userGroupDTO.GroupId,
                    GroupName = userGroupDTO.GroupName,
                    GroupCode = userGroupDTO.GroupCode,
                    GroupDesc = userGroupDTO.GroupDesc,
                    ActionUser = userGroupDTO.ActionUser,
                    IsActive = userGroupDTO.IsActive,
                    IsDeleted = userGroupDTO.IsDeleted,
                    PageSize = userGroupDTO.PageSize,
                    PageNo = userGroupDTO.PageNo,

                }, commandType: CommandType.StoredProcedure);

            }
            return response;
        }
    }
}
