using Common.Service;
using Microsoft.Extensions.Options;
using KitMaster.Interface;
using System.Data.SqlClient;
using System.Data;
using KitMaster.DTO;
using Dapper;


namespace KitMaster.Service
{
    public class KitMasterService : DABase, IKitMaster
    {
        private const string SP_KitMaster_Create = "KitMaster_Create";
        private const string SP_KitMaster_Delete = "KitMaster_Delete";
        private const string SP_KitMaster_ReadAll = "KitMaster_ReadAll";
        private const string SP_KitMaster_ReadById = "KitMaster_ReadById";
        private const string SP_KitMaster_Update = "KitMaster_Update";
        private const string SP_KitMaster_ReadAllPaginated = "KitMaster_ReadAllPaginated";
        private ILogger<KitMasterService> _logger;
        public KitMasterService(IOptions<ConnectionSettings> connectionSettings, ILogger<KitMasterService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<KitMasterDTO> Create(KitMasterCreateRequestDTO reqDTO)
        {

            KitMasterDTO retObj = null;
            _logger.LogInformation($"Started Kit Master Create {reqDTO.KName}  for desc: {reqDTO.KDescription}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<KitMasterDTO>(SP_KitMaster_Create, new
                {
                    KCode = reqDTO.KCode,
                    KName = reqDTO.KName,
                    KDescription = reqDTO.KDescription,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<KitMasterDTO> Update(KitMasterUpdateRequestDTO reqDTO)
        {

            KitMasterDTO retObj = null;
            _logger.LogInformation($"Started Kit Master Update {reqDTO.KitId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<KitMasterDTO>(SP_KitMaster_Update, new
                {
                    KitId = reqDTO.KitId,
                    KCode = reqDTO.KCode,
                    KName = reqDTO.KName,
                    KDescription = reqDTO.KDescription,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(KitMasterDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started Kit Master Delete {reqDTO.KitId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_KitMaster_Delete, new
                {
                    KitId = reqDTO.KitId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
            //return Task.CompletedTask;
        }
        public async Task<KitMasterDTO> ReadById(KitMasterReadByIdRequestDTO reqDTO)
        {

            KitMasterDTO retObj = null;
            _logger.LogInformation($"Started Kit Master ReadById {reqDTO.KitId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<KitMasterDTO>(SP_KitMaster_ReadById, new
                {
                    KitId = reqDTO.KitId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<KitMasterList> ReadAll()
        {

            KitMasterList retObj = new KitMasterList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<KitMasterDTO>(SP_KitMaster_ReadAll, new
                {

                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

        public async Task<KitMasterList> ReadAllPaginated(KitMasterReadAllPaginatedRequestDTO reqDTO)
        {

            KitMasterList retObj = new KitMasterList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<KitMasterDTO>(SP_KitMaster_ReadAllPaginated, new
                {
                    PageSize = reqDTO.PageSize,
                    PageNo = reqDTO.PageNo,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

    }
}
