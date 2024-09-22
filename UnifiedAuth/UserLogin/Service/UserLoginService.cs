using Common.Service;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using UserLogin.Interface;
using UserLogin.DTO;
using Dapper;

namespace UserLogin.Service
{
    public class UserLoginService : DABase, IUserLogin
    {
        private const string SP_UserLogin_Create = "UserLogin_Create";
        private const string SP_UserLogin_Delete = "UserLogin_Delete";
        private const string SP_UserLogin_ReadByUserId = "UserLogin_ReadByUserId";
        private const string SP_UserLogin_Update = "UserLogin_Update";
        private const string SP_UserLogin_ValidateUserName = "UserLogin_ValidateUserName";
        private const string SP_AuthenticateUser = "dbo.ValidateUserLogin";
        private const string SP_AuthenticateAzureUser = "dbo.ValidateAzureUserLogin";
        private ILogger<UserLoginService> _logger;
        public UserLoginService(IOptions<ConnectionSettings> connectionSettings, ILogger<UserLoginService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<UserLoginDTO> Create(UserLoginCreateRequestDTO reqDTO)
        {

            UserLoginDTO retObj = new UserLoginDTO();
            try
            {
                _logger.LogInformation($"Started User Login Insert {reqDTO.UserId}  for UserName: {reqDTO.UserName}");

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    retObj = await connection.QuerySingleAsync<UserLoginDTO>(SP_UserLogin_Create, new
                    {
                        UserId = reqDTO.UserId,
                        UserName = reqDTO.UserName,
                        UserPassword = reqDTO.UserPassword,
                        ActionUser = reqDTO.ActionUser,
                    }, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return retObj;
        }
        public async Task<UserLoginDTO> Update(UserLoginUpdateRequestDTO reqDTO)
        {

            UserLoginDTO retObj = null;
            _logger.LogInformation($"Started User Login Update {reqDTO.LoginId}  for Username: {reqDTO.UserName}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<UserLoginDTO>(SP_UserLogin_Update, new
                {
                    LoginId = reqDTO.LoginId,
                    UserId = reqDTO.UserId,
                    UserName = reqDTO.UserName,
                    UserPassword = reqDTO.UserPassword,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(UserLoginDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started User Login Delete {reqDTO.LoginId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_UserLogin_Delete, new
                {
                    LoginId = reqDTO.LoginId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
            //return Task.CompletedTask;
        }
        public async Task<UserLoginDTO> ReadByUserId(UserLoginReadByUserIdRequestDTO reqDTO)
        {

            UserLoginDTO retObj = null;
            _logger.LogInformation($"Started User Login ReadByUserId {reqDTO.UserId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<UserLoginDTO>(SP_UserLogin_ReadByUserId, new
                {
                    UserId = reqDTO.UserId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<ValidationResponse> ValidateUserName(UserLoginValidateUserNameRequestDTO reqDTO)
        {

            ValidationResponse retObj = new ValidationResponse();
            try
            {
                _logger.LogInformation($"Started UserName Validation {reqDTO.UserName}  for CompanyId: {reqDTO.CompanyId}");

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    retObj = await connection.QuerySingleAsync<ValidationResponse>(SP_UserLogin_ValidateUserName, new
                    {
                        CompanyId = reqDTO.CompanyId,
                        UserName = reqDTO.UserName,
                    }, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return retObj;
        }
        public async Task<UserDTO> Authenticate(string companyCode, string userName, string password)
        {
            UserDTO userInfo = null;
            try
            {
                _logger.LogInformation($"Started authenticate user {userName} for client id: {companyCode}");

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    userInfo = await connection.QuerySingleAsync<UserDTO>(SP_AuthenticateUser, new
                    {
                        UserName = userName,
                        UserPassword = password,
                        CompanyId = companyCode

                    }, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return userInfo;
        }
        public async Task<UserDTO> AuthenticateAzure(string FirstName, string LastName, string AzureUserId, string AzureEmailId, DateTime ExpiresOn)
        {

            UserDTO userInfo = null;
            _logger.LogInformation($"Started authenticate Azure user {FirstName} {LastName} for user id: {AzureUserId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                userInfo = await connection.QuerySingleAsync<UserDTO>(SP_AuthenticateAzureUser, new
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    AzureUserId = AzureUserId,
                    AzureEmailId = AzureEmailId,
                    ExpiresOn = ExpiresOn
                }, commandType: CommandType.StoredProcedure);

            }

            return userInfo;
        }
    }
}
