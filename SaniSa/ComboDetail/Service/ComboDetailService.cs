using Common.Service;
using Microsoft.Extensions.Options;
using ComboDetail.Interface;
using System.Data.SqlClient;
using System.Data;
using ComboDetail.DTO;
using Dapper;


namespace ComboDetail.Service
{
    public class ComboDetailService : DABase, IComboDetail
    {
        private const string SP_ComboDetail_Create = "ComboDetail_Create";
        private const string SP_ComboDetail_Delete = "ComboDetail_Delete";
        private const string SP_ComboDetail_ReadAll = "ComboDetail_ReadAll";
        private const string SP_ComboDetail_ReadById = "ComboDetail_ReadById";
        private const string SP_ComboDetail_ReadByComboId = "ComboDetail_ReadByComboId";
        private const string SP_ComboDetail_ReadByItemId = "ComboDetail_ReadByItemId";
        private ILogger<ComboDetailService> _logger;
        public ComboDetailService(IOptions<ConnectionSettings> connectionSettings, ILogger<ComboDetailService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<ComboDetailDTO> Create(ComboDetailCreateRequestDTO reqDTO)
        {

            ComboDetailDTO retObj = null;
            _logger.LogInformation($"Started Combo Detail Create {reqDTO.ItemId}  for ItemPrice: {reqDTO.ItemPrice}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<ComboDetailDTO>(SP_ComboDetail_Create, new
                {
                    ComboId = reqDTO.ComboId,
                    ItemId = reqDTO.ItemId,
                    ItemPrice = reqDTO.ItemPrice,
                    Units = reqDTO.Units,
                    TotalAmt = reqDTO.TotalAmt,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<ComboDetailDTO> ReadByItemId(ComboDetailReadByItemIdRequestDTO reqDTO)
        {

            ComboDetailDTO retObj = null;
            _logger.LogInformation($"Started Combo Detail ReadByItemId {reqDTO.ItemId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<ComboDetailDTO>(SP_ComboDetail_ReadByItemId, new
                {
                    ItemId = reqDTO.ItemId
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(ComboDetailDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started Combo Detail Delete {reqDTO.DetailId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_ComboDetail_Delete, new
                {
                    DetailId = reqDTO.DetailId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
            //return Task.CompletedTask;
        }
        public async Task<ComboDetailDTO> ReadById(ComboDetailReadByIdRequestDTO reqDTO)
        {

            ComboDetailDTO retObj = null;
            _logger.LogInformation($"Started Combo Detail ReadById {reqDTO.DetailId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<ComboDetailDTO>(SP_ComboDetail_ReadById, new
                {
                    DetailId = reqDTO.DetailId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<ComboDetailDTO> ReadByComboId(ComboDetailReadByComboIdRequestDTO reqDTO)
        {

            ComboDetailDTO retObj = null;
            _logger.LogInformation($"Started Combo Detail ReadByComboId {reqDTO.ComboId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<ComboDetailDTO>(SP_ComboDetail_ReadByComboId, new
                {
                    ComboId = reqDTO.ComboId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<ComboDetailList> ReadAll()
        {

            ComboDetailList retObj = new ComboDetailList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<ComboDetailDTO>(SP_ComboDetail_ReadAll, new
                {

                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

    }
}
