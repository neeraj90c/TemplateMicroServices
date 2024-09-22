using Common.Service;
using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using UserMaster.DTO;
using UserMaster.Interface;

namespace UserMaster.Service
{
    public class UserMasterService: DABase, IUserMaster
    {
        private const string SP_UserMaster_Create = "UserMaster_Create";
        private const string SP_UserMaster_Delete = "UserMaster_Delete";
        private const string SP_UserMaster_ReadAll = "UserMaster_ReadAll";
        private const string SP_UserMaster_ReadAllPaginated = "UserMaster_ReadAllPaginated";
        private const string SP_UserMaster_ReadByUserId = "UserMaster_ReadByUserId";
        private const string SP_UserMaster_Update = "UserMaster_Update";
        private const string SP_UserMaster_UpdateStatus = "UserMaster_UpdateStatus";
        private ILogger<UserMasterService> _logger;
        public UserMasterService(IOptions<ConnectionSettings> connectionSettings, ILogger<UserMasterService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<UserDTO> Create(UserCreateRequestDTO reqDTO)
        {

            UserDTO retObj = null;
            _logger.LogInformation($"Started User Master Insert {reqDTO.FirstName}  for Email: {reqDTO.EmailId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<UserDTO>(SP_UserMaster_Create, new
                {
                    CompanyId = reqDTO.CompanyId,
                    FirstName = reqDTO.FirstName,
                    MiddleName = reqDTO.MiddleName,
                    LastName = reqDTO.LastName,
                    DOB = reqDTO.DOB,
                    MobileNo = reqDTO.MobileNo,
                    EmailId = reqDTO.EmailId,
                    Designation = reqDTO.Designation,
                    ProfileImage = reqDTO.ProfileImage,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<UserDTO> Update(UserUpdateRequestDTO reqDTO)
        {

            UserDTO retObj = null;
            _logger.LogInformation($"Started User Master Update {reqDTO.UserId}  for Name: {reqDTO.FirstName}:{reqDTO.LastName}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<UserDTO>(SP_UserMaster_Update, new
                {
                    UserId = reqDTO.UserId,
                    CompanyId = reqDTO.CompanyId,
                    FirstName = reqDTO.FirstName,
                    MiddleName = reqDTO.MiddleName,
                    LastName = reqDTO.LastName,
                    DOB = reqDTO.DOB,
                    MobileNo = reqDTO.MobileNo,
                    EmailId = reqDTO.EmailId,
                    Designation = reqDTO.Designation,
                    ProfileImage = reqDTO.ProfileImage,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(UserDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started User Master Delete {reqDTO.UserId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_UserMaster_Delete, new
                {
                    UserId = reqDTO.UserId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
            //return Task.CompletedTask;
        }
        public async Task<UserDTO> ReadById(UserReadByUserIdRequestDTO reqDTO)
        {

            UserDTO retObj = null;
            _logger.LogInformation($"Started User Master ReadById {reqDTO.UserId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<UserDTO>(SP_UserMaster_ReadByUserId, new
                {
                    UserId = reqDTO.UserId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<UserList> ReadAll()
        {

            UserList retObj = new UserList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<UserDTO>(SP_UserMaster_ReadAll, new
                {

                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<UserList> ReadAllPaginated(UserReadAllPaginatedRequestDTO reqDTO)
        {

            UserList retObj = new UserList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<UserDTO>(SP_UserMaster_ReadAllPaginated, new
                {
                    ProjectId = reqDTO.ProjectId,
                    CompanyId = reqDTO.CompanyId,
                    PageSize = reqDTO.PageSize,
                    PageNo = reqDTO.PageNo,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<UserDTO> UpdateStatus(UserUpdateStatusRequestDTO reqDTO)
        {

            UserDTO retObj = null;
            _logger.LogInformation($"Started User Master Update Status: {reqDTO.UserId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<UserDTO>(SP_UserMaster_UpdateStatus, new
                {
                    UserId = reqDTO.UserId,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
    }
}
