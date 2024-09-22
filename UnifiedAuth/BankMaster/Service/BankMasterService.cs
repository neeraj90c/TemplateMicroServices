using BankMaster.Interface;
using Common.DTO;
using Common.Service;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using BankMaster.DTO;
using Dapper;

namespace BankMaster.Service
{
    public class BankMasterService: DABase , IBankMaster
    {
        private const string SP_BankMaster_Create = "BankMaster_Create";
        private const string SP_BankMaster_Delete = "BankMaster_Delete";
        private const string SP_BankMaster_ReadAll = "BankMaster_ReadAll";
        private const string SP_BankMaster_ReadAllPaginated = "BankMaster_ReadAllPaginated";
        private const string SP_BankMaster_ReadById = "BankMaster_ReadById";
        private const string SP_BankMaster_Update = "BankMaster_Update";
        private ILogger<BankMasterService> _logger;
        public BankMasterService(IOptions<ConnectionSettings> connectionSettings, ILogger<BankMasterService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<BankMasterDTO> Create(BankMasterCreateRequestDTO reqDTO)
        {

            BankMasterDTO retObj = null;
            _logger.LogInformation($"Started Bank Master Create {reqDTO.BankName} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<BankMasterDTO>(SP_BankMaster_Create, new
                {
                    BankName = reqDTO.BankName,
                    BankBranch = reqDTO.BankBranch,
                    BankAddress = reqDTO.BankAddress,
                    IFSCCode = reqDTO.IFSCCode,
                    Remarks = reqDTO.Remarks,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<BankMasterDTO> Update(BankMasterUpdateRequestDTO reqDTO)
        {

            BankMasterDTO retObj = null;
            _logger.LogInformation($"Started Bank Master Update {reqDTO.BankId}  for Bank: {reqDTO.BankName}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<BankMasterDTO>(SP_BankMaster_Update, new
                {
                    BankId = reqDTO.BankId,
                    BankName = reqDTO.BankName,
                    BankBranch = reqDTO.BankBranch,
                    BankAddress = reqDTO.BankAddress,
                    IFSCCode = reqDTO.IFSCCode,
                    Remarks = reqDTO.Remarks,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(BankMasterDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started Bank Master Delete {reqDTO.BankId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_BankMaster_Delete, new
                {
                    BankId = reqDTO.BankId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
        }
        public async Task<BankMasterDTO> ReadById(BankMasterReadByIdRequestDTO reqDTO)
        {

            BankMasterDTO retObj = null;
            _logger.LogInformation($"Started Bank Master ReadById {reqDTO.BankId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<BankMasterDTO>(SP_BankMaster_ReadById, new
                {
                    BankId = reqDTO.BankId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<BankMasterList> ReadAll()
        {

            BankMasterList retObj = new BankMasterList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<BankMasterDTO>(SP_BankMaster_ReadAll, new
                {
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<BankMasterList> ReadAllPaginated(PaginationDTO reqDTO)
        {

            BankMasterList retObj = new BankMasterList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<BankMasterDTO>(SP_BankMaster_ReadAllPaginated, new
                {
                    PageSize = reqDTO.PageSize,
                    PageNo = reqDTO.PageNo,
                    WhereClause = reqDTO.WhereClause,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
    }
}
