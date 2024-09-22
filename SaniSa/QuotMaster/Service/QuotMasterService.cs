using Common.Service;
using Microsoft.Extensions.Options;
using QuotMaster.Interface;
using System.Data.SqlClient;
using System.Data;
using QuotMaster.DTO;
using Dapper;


namespace QuotMaster.Service
{
    public class QuotMasterService : DABase, IQuotMaster
    {
        private const string SP_QuotMaster_Create = "QMaster_Create";
        private const string SP_QuotMaster_Delete = "QMaster_Delete";
        private const string SP_QuotMaster_ReadAll = "QMaster_ReadAll";
        private const string SP_QuotMaster_ReadById = "QMaster_ReadById";
        private const string SP_QuotMaster_Update = "QMaster_Update";
        private const string SP_QuotMaster_ReadAllPaginated = "QMaster_ReadAllPaginated";
        private ILogger<QuotMasterService> _logger;
        public QuotMasterService(IOptions<ConnectionSettings> connectionSettings, ILogger<QuotMasterService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<QuotMasterDTO> Create(QuotMasterCreateRequestDTO reqDTO)
        {

            QuotMasterDTO retObj = null;
            _logger.LogInformation($"Started Quot Master Create {reqDTO.QName}  for desc: {reqDTO.QDesc}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<QuotMasterDTO>(SP_QuotMaster_Create, new
                {
                    QName = reqDTO.QName,
                    QCode = reqDTO.QCode,
                    QDesc = reqDTO.QDesc,
                    QDate = reqDTO.QDate,
                    QRange = reqDTO.QRange,
                    QMod = reqDTO.QMod,
                    ClientId = reqDTO.ClientId,
                    QStatus = reqDTO.QStatus,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<QuotMasterDTO> Update(QuotMasterUpdateRequestDTO reqDTO)
        {

            QuotMasterDTO retObj = null;
            _logger.LogInformation($"Started Quot Master Update {reqDTO.QuotId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<QuotMasterDTO>(SP_QuotMaster_Update, new
                {
                    QuotId = reqDTO.QuotId,
                    QName = reqDTO.QName,
                    QCode = reqDTO.QCode,
                    QDesc = reqDTO.QDesc,
                    QDate = reqDTO.QDate,
                    QRange = reqDTO.QRange,
                    QMod = reqDTO.QMod,
                    ClientId = reqDTO.ClientId,
                    QStatus = reqDTO.QStatus,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(QuotMasterDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started Quot Master Delete {reqDTO.QuotId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_QuotMaster_Delete, new
                {
                    QuotId = reqDTO.QuotId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
            //return Task.CompletedTask;
        }
        public async Task<QuotMasterDTO> ReadById(QuotMasterReadByIdRequestDTO reqDTO)
        {

            QuotMasterDTO retObj = null;
            _logger.LogInformation($"Started Quot Master ReadById {reqDTO.QuotId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<QuotMasterDTO>(SP_QuotMaster_ReadById, new
                {
                    QuotId = reqDTO.QuotId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<QuotMasterList> ReadAll()
        {

            QuotMasterList retObj = new QuotMasterList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<QuotMasterDTO>(SP_QuotMaster_ReadAll, new
                {

                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

        public async Task<QuotMasterList> ReadAllPaginated(QuotMasterReadAllPaginatedRequestDTO reqDTO)
        {

            QuotMasterList retObj = new QuotMasterList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<QuotMasterDTO>(SP_QuotMaster_ReadAllPaginated, new
                {
                    PageSize = reqDTO.PageSize,
                    PageNo = reqDTO.PageNo,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

    }
}
