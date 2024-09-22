using AzureAuth.Interface;
using Common.Service;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using AzureAuth.DTO;
using Dapper;

namespace AzureAuth.Service
{
    public class AzureAuthService : DABase, IAzureAuth
    {
        private const string SP_AzureUserMaster_Create = "AzureUserMaster_Create";
        private const string SP_AzureUserMaster_Delete = "AzureUserMaster_Delete";
        private const string SP_AzureUserMaster_ReadAll = "AzureUserMaster_ReadAll";
        private const string SP_AzureUserMaster_ReadById = "AzureUserMaster_ReadById";
        private const string SP_AzureUserMaster_Update = "AzureUserMaster_Update";
        private const string SP_AzureUserMaster_ReadByAzureUUId = "AzureUserMaster_ReadByAzureUUId" +
            "";
        private ILogger<AzureAuthService> _logger;
        public AzureAuthService(IOptions<ConnectionSettings> connectionSettings, ILogger<AzureAuthService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<AzureAuthDTO> Create(AzureAuthCreateRequestDTO reqDTO)
        {

            AzureAuthDTO retObj = null;
            _logger.LogInformation($"Started Azure Auth Create {reqDTO.UserId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleOrDefaultAsync<AzureAuthDTO>(SP_AzureUserMaster_Create, new
                {
                    UserId = reqDTO.UserId,
                    FirstName = reqDTO.FirstName,
                    LastName = reqDTO.LastName,
                    AUserId = reqDTO.AUserId,
                    AEmailId = reqDTO.AEmailId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<AzureAuthDTO> Update(AzureAuthUpdateRequestDTO reqDTO)
        {

            AzureAuthDTO retObj = null;
            _logger.LogInformation($"Started Azure Auth Update {reqDTO.UserId}  for Detail: {reqDTO.AzureUserId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleOrDefaultAsync<AzureAuthDTO>(SP_AzureUserMaster_Update, new
                {
                    AzureUserId = reqDTO.AzureUserId,
                    UserId = reqDTO.UserId,
                    FirstName = reqDTO.FirstName,
                    LastName = reqDTO.LastName,
                    AUserId = reqDTO.AUserId,
                    AEmailId = reqDTO.AEmailId,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(AzureAuthDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started Azure Auth Delete {reqDTO.AzureUserId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_AzureUserMaster_Delete, new
                {
                    AzureUserId = reqDTO.AzureUserId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
        }
        public async Task<AzureAuthDTO> ReadById(AzureAuthReadByIdRequestDTO reqDTO)
        {

            AzureAuthDTO retObj = null;
            _logger.LogInformation($"Started Azure Auth ReadById {reqDTO.AzureUserId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleOrDefaultAsync<AzureAuthDTO>(SP_AzureUserMaster_ReadById, new
                {
                    AzureUserId = reqDTO.AzureUserId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<AzureAuthDTO> ReadByAzureUUId(AzureAuthReadByAzureUUIdRequestDTO reqDTO)
        {

            AzureAuthDTO retObj = null;
            _logger.LogInformation($"Started Azure Auth ReadByAzureUUId {reqDTO.AzureUUID}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleOrDefaultAsync<AzureAuthDTO>(SP_AzureUserMaster_ReadByAzureUUId, new
                {
                    AzureUUID = reqDTO.AzureUUID,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<AzureAuthList> ReadAll()
        {

            AzureAuthList retObj = new AzureAuthList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<AzureAuthDTO>(SP_AzureUserMaster_ReadAll, new
                {

                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
    }
}
