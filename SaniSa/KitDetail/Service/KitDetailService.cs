using Common.Service;
using Microsoft.Extensions.Options;
using KitDetail.Interface;
using System.Data.SqlClient;
using System.Data;
using KitDetail.DTO;
using Dapper;


namespace KitDetail.Service
{
    public class KitDetailService : DABase, IKitDetail
    {
        private const string SP_KitDetail_Create = "KitDetail_Create";
        private const string SP_KitDetail_Delete = "KitDetail_Delete";
        private const string SP_KitDetail_ReadAll = "KitDetail_ReadAll";
        private const string SP_KitDetail_ReadById = "KitDetail_ReadById";
        private const string SP_KitDetail_ReadByKitId = "KitDetail_ReadByKitId";
        private const string SP_KitDetail_Update = "KitDetail_Update";
        private ILogger<KitDetailService> _logger;
        public KitDetailService(IOptions<ConnectionSettings> connectionSettings, ILogger<KitDetailService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<KitDetailDTO> Create(KitDetailCreateRequestDTO reqDTO)
        {

            KitDetailDTO retObj = null;
            _logger.LogInformation($"Started Kit Detail Create {reqDTO.ItemId}  for remarks: {reqDTO.Remarks}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<KitDetailDTO>(SP_KitDetail_Create, new
                {
                    ItemId = reqDTO.ItemId,
                    Remarks = reqDTO.Remarks,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<KitDetailDTO> Update(KitDetailUpdateRequestDTO reqDTO)
        {

            KitDetailDTO retObj = null;
            _logger.LogInformation($"Started Kit Detail Update {reqDTO.DetailId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<KitDetailDTO>(SP_KitDetail_Update, new
                {
                    DetailId = reqDTO.DetailId,
                    ItemId = reqDTO.ItemId,
                    Remarks = reqDTO.Remarks,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(KitDetailDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started Kit Detail Delete {reqDTO.DetailId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_KitDetail_Delete, new
                {
                    DetailId = reqDTO.DetailId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
            //return Task.CompletedTask;
        }
        public async Task<KitDetailDTO> ReadById(KitDetailReadByIdRequestDTO reqDTO)
        {

            KitDetailDTO retObj = null;
            _logger.LogInformation($"Started Kit Detail ReadById {reqDTO.DetailId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<KitDetailDTO>(SP_KitDetail_ReadById, new
                {
                    DetailId = reqDTO.DetailId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<KitDetailDTO> ReadByKitId(KitDetailReadByKitIdRequestDTO reqDTO)
        {

            KitDetailDTO retObj = null;
            _logger.LogInformation($"Started Kit Detail ReadByKitId {reqDTO.KitId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<KitDetailDTO>(SP_KitDetail_ReadByKitId, new
                {
                    KitId = reqDTO.KitId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<KitDetailList> ReadAll()
        {

            KitDetailList retObj = new KitDetailList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<KitDetailDTO>(SP_KitDetail_ReadAll, new
                {

                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

    }
}
