using AuthenticationService.DTO;
using AuthenticationService.Interface;
using Common.DTO;
using Common.Service;
using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices.Protocols;
using System.Drawing.Printing;

namespace AuthenticationService.Service
{
    public class UserService : DABase, IUserContract, IUserMaster
    {
        APISettings _settings;
        ConnectionSettings _connectionSettings;
        private const string SP_AuthenticateUser = "dbo.ValidateUserLogin";
        private const string SP_AuthenticateAzureUser = "dbo.ValidateAzureUserLogin";
        private const string SP_UserMaster_CRUD = "dbo.UserMaster_CRUD";
        private const string SP_PaginatedUserMaster_CRUD = "dbo.PaginatedUserMaster_CRUD";
        private const string SP_UserLogin_CRUD = "dbo.UserLogin_CRUD";
        private const string SP_UserWorkCenter_CRUD = "dbo.UserWorkCenter_CRUD";
        private const string SP_Dashboard_GetAllUserDetails = "dbo.Dashboard_GetAllUserDetails";
        private const string SP_UserMaster_UpdateStatus = "dbo.UserMaster_UpdateStatus";
        private const string SP_GetCompanyName = "dbo.GetCompanyName";
        private const string SP_UserMaster_LoadAllDDL = "dbo.UserMaster_LoadAllDDL";
        private const string SP_UserMaster_ReadAllPaginated = "UserMaster_ReadAllPaginated";

        private ILogger<UserService> _logger;


        public UserService(IOptions<ConnectionSettings> connectionSettings, ILogger<UserService> logger, IOptions<APISettings> settings) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
            _settings = settings.Value;
            _connectionSettings = connectionSettings.Value;
        }
        public async Task<UserDTO> Authenticate(string companyCode, string userName, string password)
        {
            UserDTO userInfo = null;
            try
            {
                if (_connectionSettings.PrintConnectionString == "Y")
                {
                    _logger.LogInformation($"AppKeyPath :{_connectionSettings.AppKeyPath} ");
                    _logger.LogInformation($"DBCONN :{_connectionSettings.DBCONN} ");
                    //_logger.LogInformation($"Connection String :{ConnectionString} ");
                }
                _logger.LogInformation($"Started authenticate user {userName} for client id: {companyCode}");

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    userInfo = await connection.QuerySingleOrDefaultAsync<UserDTO>(SP_AuthenticateUser, new
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
        public static bool User()
        {
            bool validation;
            try
            {
                validation = true;
            }
            catch (LdapException)
            {
                validation = false;
            }
            return validation;
        }

        public async Task<UserList> UserCRUD(UserMasterDTO userMasterDTO)
        {
            UserList response = new UserList();
            try
            {
                var filename = (DateTime.Now).Ticks;
                var filepath = " ";
                //Save the file
                if (!System.String.IsNullOrEmpty(userMasterDTO.ProfileImageBase64) && userMasterDTO.IsDeleted == 0 && userMasterDTO.ProfileImageBase64.Trim() != "" && userMasterDTO.ProfileImageBase64.Trim() != "string")
                {
                    string filePath = $"{_settings.UploadPath}\\Users\\ProfileImages\\{filename}";
                    filepath = Utilities.SaveFileFromBase64(userMasterDTO.WebRootPath, filePath, userMasterDTO.ProfileImageBase64);
                }
                else
                {
                    filepath = userMasterDTO.ProfileImage;
                }

                _logger.LogInformation($"Started fetching all Users to View {userMasterDTO.UserId}");

                using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                {
                    response.Users = await connection.QueryAsync<UserMasterDTO>(SP_UserMaster_CRUD, new
                    {
                        UserId = userMasterDTO.UserId,
                        FirstName = userMasterDTO.FirstName,
                        MiddleName = userMasterDTO.MiddleName,
                        LastName = userMasterDTO.LastName,
                        DOB = userMasterDTO.DOB,
                        MobileNo = userMasterDTO.MobileNo,
                        EmailId = userMasterDTO.EmailId,
                        Designation = userMasterDTO.Designation,
                        IsActive = userMasterDTO.IsActive,
                        IsDeleted = userMasterDTO.IsDeleted,
                        ActionUser = userMasterDTO.ActionUser,
                        ProfileImage = filepath,
                        CompanyId = userMasterDTO.CompanyId,
                        ProjectId = userMasterDTO.ProjectId,

                    }, commandType: CommandType.StoredProcedure);

                }

                foreach (var item in response.Users)
                {
                    if (File.Exists(item.ProfileImage))
                    {
                        byte[] fileBytes = File.ReadAllBytes(item.ProfileImage);
                        string base64String = Convert.ToBase64String(fileBytes);
                        item.ProfileImageBase64 = base64String;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public async Task<UserList> PaginatedUserCRUD(UserMasterDTO userMasterDTO)
        {
            UserList response = new UserList();
            try
            {
                var filename = (DateTime.Now).Ticks;
                var filepath = " ";
                //Save the file
                if (!System.String.IsNullOrEmpty(userMasterDTO.ProfileImageBase64) && userMasterDTO.IsDeleted == 0 && userMasterDTO.ProfileImageBase64.Trim() != "" && userMasterDTO.ProfileImageBase64.Trim() != "string")
                {
                    string filePath = $"{_settings.UploadPath}\\Users\\ProfileImages\\{filename}";
                    filepath = Utilities.SaveFileFromBase64(userMasterDTO.WebRootPath, filePath, userMasterDTO.ProfileImageBase64);
                }
                else
                {
                    filepath = userMasterDTO.ProfileImage;
                }

                _logger.LogInformation($"Started fetching all Users to View {userMasterDTO.UserId}");

                using (SqlConnection connection = new SqlConnection(base.ConnectionString))
                {
                    response.Users = await connection.QueryAsync<UserMasterDTO>(SP_PaginatedUserMaster_CRUD, new
                    {
                        UserId = userMasterDTO.UserId,
                        FirstName = userMasterDTO.FirstName,
                        MiddleName = userMasterDTO.MiddleName,
                        LastName = userMasterDTO.LastName,
                        DOB = userMasterDTO.DOB,
                        MobileNo = userMasterDTO.MobileNo,
                        EmailId = userMasterDTO.EmailId,
                        Designation = userMasterDTO.Designation,
                        IsActive = userMasterDTO.IsActive,
                        IsDeleted = userMasterDTO.IsDeleted,
                        ActionUser = userMasterDTO.ActionUser,
                        ProfileImage = filepath,
                        CompanyId = userMasterDTO.CompanyId,
                        ProjectId = userMasterDTO.ProjectId,
                        PageSize = userMasterDTO.PageSize,
                        PageNo = userMasterDTO.PageNo,

                    }, commandType: CommandType.StoredProcedure);

                }

                foreach (var item in response.Users)
                {
                    if (File.Exists(item.ProfileImage))
                    {
                        byte[] fileBytes = File.ReadAllBytes(item.ProfileImage);
                        string base64String = Convert.ToBase64String(fileBytes);
                        item.ProfileImageBase64 = base64String;

                        item.ProfileImage = $"{_settings.DocumentUploadBaseUrl}\\{item.ProfileImage}";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public async Task<UserList> CreateUserCredentials(UserCredDTO userCredDTO)
        {

            _logger.LogInformation($"Started creating user credentials for user: {userCredDTO.UserName}");

            UserList response = new UserList();


            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                response.Users = await connection.QueryAsync<UserMasterDTO>(SP_UserLogin_CRUD, new
                {
                    UserId = userCredDTO.UserId,
                    UserName = userCredDTO.UserName,
                    UserPassword = userCredDTO.UserPassword,
                    ActionUser = userCredDTO.ActionUser
                }, commandType: CommandType.StoredProcedure);
            }
            foreach (var item in response.Users)
            {
                if (File.Exists(item.ProfileImage))
                {
                    byte[] fileBytes = File.ReadAllBytes(item.ProfileImage);
                    string base64String = Convert.ToBase64String(fileBytes);
                    item.ProfileImageBase64 = base64String;
                }
            }


            return response;
        }

        public async Task<UserWorkCenterList> UserWorkCenterCRUD(UserWorkCenterDTO userWorkCenterDTO)
        {
            UserWorkCenterList response = new UserWorkCenterList();

            _logger.LogInformation($"Started Executing UserWorkcenter Mapping and retrieving workcenters assigned to user: {userWorkCenterDTO.UserWorkCenterId}");
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                response.UserWorkCenter = await connection.QueryAsync<UserWorkCenterDTO>(SP_UserWorkCenter_CRUD, new
                {

                    UserWorkCenterId = userWorkCenterDTO.UserWorkCenterId,
                    UserId = userWorkCenterDTO.UserId,
                    WorkCenterId = userWorkCenterDTO.WorkCenterId,
                    ActionUser = userWorkCenterDTO.ActionUser,
                    IsActive = userWorkCenterDTO.IsActive,
                    IsDeleted = userWorkCenterDTO.IsDeleted

                }, commandType: CommandType.StoredProcedure);
            }


            return response;

        }

        public async Task<UserDashboardList> UserDashboardGet(UserDashboardDTO userDashboardDTO)
        {
            UserDashboardList response = new UserDashboardList();

            _logger.LogInformation($"fetching data for userDashboard: {userDashboardDTO.ActionUser}");
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                response.UserDashboardDetails = await connection.QueryAsync<UserDashboardDTO>(SP_Dashboard_GetAllUserDetails, new
                {
                    ActionUser = userDashboardDTO.ActionUser

                }, commandType: CommandType.StoredProcedure);
            }


            return response;

        }

        public async Task<UserMasterDTO> UserStatusUpdate(UserMasterDTO userMasterDTO)
        {
            UserMasterDTO response = new UserMasterDTO();

            _logger.LogInformation($"Updating User Status as Active or Inactive for user: {userMasterDTO.ActionUser}");
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                response = await connection.QueryFirstOrDefaultAsync<UserMasterDTO>(SP_UserMaster_UpdateStatus, new
                {
                    ActionUser = userMasterDTO.ActionUser,
                    IsActive = userMasterDTO.IsActive,
                    UserId = userMasterDTO.UserId
                }, commandType: CommandType.StoredProcedure);
            }
            return response;
        }
        public async Task<DropDownList> GetAllUserList()
        {
            DropDownList response = new DropDownList();

            _logger.LogInformation($"fetching data for User List");
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                response.dropDownList = await connection.QueryAsync<DropDownDTO>(SP_UserMaster_LoadAllDDL, commandType: CommandType.StoredProcedure);
            }


            return response;
        }
        public async Task<CompanyList> GetCompany()
        {
            CompanyList response = new CompanyList();

            _logger.LogInformation($"fetching data for Company List");
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                response.Companies = await connection.QueryAsync<CompanyMasterDTO>(SP_GetCompanyName, commandType: CommandType.StoredProcedure);
            }


            return response;
        }
        public async Task<UserDTO> AuthenticateAzure(string FirstName, string LastName, string AzureUserId, string AzureEmailId, DateTime ExpiresOn)
        {

            UserDTO userInfo = null;
            _logger.LogInformation($"Started authenticate Azure user {FirstName} {LastName} for user id: {AzureUserId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                userInfo = await connection.QuerySingleOrDefaultAsync<UserDTO>(SP_AuthenticateAzureUser, new
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
