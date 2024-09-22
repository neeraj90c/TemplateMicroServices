using Common.Service;
using Microsoft.Extensions.Options;
using QuoteDetail.Interface;
using System.Data.SqlClient;
using System.Data;
using QuoteDetail.DTO;
using Dapper;


namespace QuoteDetail.Service
{
    public class QuoteDetailService : DABase, IQuoteDetail
    {
        private const string SP_QuoteDetail_Create = "QDetail_Create";
        private const string SP_QuoteDetail_Delete = "QDetail_Delete";
        private const string SP_QuoteDetail_ReadAll = "QDetail_ReadAll";
        private const string SP_QuoteDetail_ReadById = "QDetail_ReadById";
        private const string SP_QuoteDetail_ReadByQuotId = "QDetail_ReadByQuotId";
        private const string SP_QuoteDetail_Update = "QDetail_Update";
        private ILogger<QuoteDetailService> _logger;
        public QuoteDetailService(IOptions<ConnectionSettings> connectionSettings, ILogger<QuoteDetailService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<QuoteDetailDTO> Create(QuoteDetailCreateRequestDTO reqDTO)
        {

            QuoteDetailDTO retObj = null;
            _logger.LogInformation($"Started Quot Detail Create {reqDTO.QuotId}  for DetailId : {reqDTO.IDetailId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<QuoteDetailDTO>(SP_QuoteDetail_Create, new
                {
                    QuotId = reqDTO.QuotId,
                    IDetailId = reqDTO.IDetailId,
                    IDetailType = reqDTO.IDetailType,
                    IMRP = reqDTO.IMRP,
                    IPrice = reqDTO.IPrice,
                    IDesc = reqDTO.IDesc,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<QuoteDetailDTO> Update(QuoteDetailUpdateRequestDTO reqDTO)
        {

            QuoteDetailDTO retObj = null;
            _logger.LogInformation($"Started Quot Detail Update {reqDTO.DetailId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<QuoteDetailDTO>(SP_QuoteDetail_Update, new
                {
                    DetailId = reqDTO.DetailId,
                    QuotId = reqDTO.QuotId,
                    IDetailId = reqDTO.IDetailId,
                    IDetailType = reqDTO.IDetailType,
                    IMRP = reqDTO.IMRP,
                    IPrice = reqDTO.IPrice,
                    IDesc = reqDTO.IDesc,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(QuoteDetailDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started Quot Detail Delete {reqDTO.DetailId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_QuoteDetail_Delete, new
                {
                    DetailId = reqDTO.DetailId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
            //return Task.CompletedTask;
        }
        public async Task<QuoteDetailDTO> ReadById(QuoteDetailReadByIdRequestDTO reqDTO)
        {

            QuoteDetailDTO retObj = null;
            _logger.LogInformation($"Started Quot Detail ReadById {reqDTO.DetailId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<QuoteDetailDTO>(SP_QuoteDetail_ReadById, new
                {
                    DetailId = reqDTO.DetailId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<QuoteDetailDTO> ReadByQuotId(QuoteDetailReadByQuotIdRequestDTO reqDTO)
        {

            QuoteDetailDTO retObj = null;
            _logger.LogInformation($"Started Quot Detail ReadByQuotId {reqDTO.QuotId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<QuoteDetailDTO>(SP_QuoteDetail_ReadByQuotId, new
                {
                    QuotId = reqDTO.QuotId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<QuoteDetailList> ReadAll()
        {

            QuoteDetailList retObj = new QuoteDetailList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<QuoteDetailDTO>(SP_QuoteDetail_ReadAll, new
                {

                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

    }
}
