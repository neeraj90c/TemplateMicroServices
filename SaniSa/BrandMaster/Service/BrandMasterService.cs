using Common.Service;
using Microsoft.Extensions.Options;
using BrandMaster.Interface;
using System.Data.SqlClient;
using System.Data;
using BrandMaster.DTO;
using Dapper;


namespace BrandMaster.Service
{
    public class BrandMasterService : DABase, IBrandMaster
    {
        private const string SP_BrandMaster_Create = "BrandMaster_Create";
        private const string SP_BrandMaster_Delete = "BrandMaster_Delete";
        private const string SP_BrandMaster_ReadAll = "BrandMaster_ReadAll";
        private const string SP_BrandMaster_ReadById = "BrandMaster_ReadById";
        private const string SP_BrandMaster_Update = "BrandMaster_Update";
        private const string SP_BrandMaster_ReadAllPaginated = "BrandMaster_ReadAllPaginated";
        private ILogger<BrandMasterService> _logger;
        public BrandMasterService(IOptions<ConnectionSettings> connectionSettings, ILogger<BrandMasterService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<BrandMasterDTO> Create(BrandMasterCreateRequestDTO reqDTO)
        {

            BrandMasterDTO retObj = null;
            _logger.LogInformation($"Started Brand Master Create {reqDTO.BName}  for desc: {reqDTO.BDesc}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<BrandMasterDTO>(SP_BrandMaster_Create, new
                {
                    CompanyId = reqDTO.CompanyId,
                    BName = reqDTO.BName,
                    BCode = reqDTO.BCode,
                    BDesc = reqDTO.BDesc,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<BrandMasterDTO> Update(BrandMasterUpdateRequestDTO reqDTO)
        {

            BrandMasterDTO retObj = null;
            _logger.LogInformation($"Started Brand Master Update {reqDTO.BrandId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<BrandMasterDTO>(SP_BrandMaster_Update, new
                {
                    BrandId = reqDTO.BrandId,
                    BCode = reqDTO.BCode,
                    BName = reqDTO.BName,
                    BDesc = reqDTO.BDesc,
                    CompanyId = reqDTO.CompanyId,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(BrandMasterDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started Brand Master Delete {reqDTO.BrandId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_BrandMaster_Delete, new
                {
                    BrandId = reqDTO.BrandId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
            //return Task.CompletedTask;
        }
        public async Task<BrandMasterDTO> ReadById(BrandMasterReadByIdRequestDTO reqDTO)
        {

            BrandMasterDTO retObj = null;
            _logger.LogInformation($"Started Brand Master ReadById {reqDTO.BrandId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<BrandMasterDTO>(SP_BrandMaster_ReadById, new
                {
                    BrandId = reqDTO.BrandId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<BrandMasterList> ReadAll()
        {

            BrandMasterList retObj = new BrandMasterList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<BrandMasterDTO>(SP_BrandMaster_ReadAll, new
                {

                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

        public async Task<BrandMasterList> ReadAllPaginated(BrandMasterReadAllPaginatedRequestDTO reqDTO)
        {

            BrandMasterList retObj = new BrandMasterList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<BrandMasterDTO>(SP_BrandMaster_ReadAllPaginated, new
                {
                    PageSize = reqDTO.PageSize,
                    PageNo = reqDTO.PageNo,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

    }
}
