using Common.Service;
using CompanyMaster.Interface;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using CompanyMaster.DTO;

namespace CompanyMaster.Service
{
    public class CompanyMasterService : DABase, ICompanyMaster
    {
        private const string SP_CompanyMaster_Create = "CompanyMaster_Create";
        private const string SP_CompanyMaster_Delete = "CompanyMaster_Delete";
        private const string SP_CompanyMaster_ReadAll = "CompanyMaster_ReadAll";
        private const string SP_CompanyMaster_ReadById = "CompanyMaster_ReadById";
        private const string SP_CompanyMaster_Update = "CompanyMaster_Update";
        private ILogger<CompanyMasterService> _logger;
        public CompanyMasterService(IOptions<ConnectionSettings> connectionSettings, ILogger<CompanyMasterService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<CompanyMasterDTO> Create(CompanyMasterCreateRequestDTO reqDTO)
        {

            CompanyMasterDTO retObj = null;
            _logger.LogInformation($"Started Company Master Insert {reqDTO.CName}  for Email: {reqDTO.Email}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<CompanyMasterDTO>(SP_CompanyMaster_Create, new
                {
                    CName = reqDTO.CName,
                    CCode = reqDTO.CCode,
                    CDesc = reqDTO.CDesc,
                    CAddress = reqDTO.CAddress,
                    Email = reqDTO.Email,
                    Phone = reqDTO.Phone,
                    Website = reqDTO.Website,
                    Category = reqDTO.Category,
                    SubCategory = reqDTO.SubCategory,
                    ContactPerson = reqDTO.ContactPerson,
                    CType = reqDTO.CType,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<CompanyMasterDTO> Update(CompanyMasterUpdateRequestDTO reqDTO)
        {

            CompanyMasterDTO retObj = null;
            _logger.LogInformation($"Started Company Master Update {reqDTO.CompanyId}  for CName: {reqDTO.CName}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<CompanyMasterDTO>(SP_CompanyMaster_Update, new
                {
                    CompanyId = reqDTO.CompanyId,
                    CName = reqDTO.CName,
                    CCode = reqDTO.CCode,
                    CDesc = reqDTO.CDesc,
                    CAddress = reqDTO.CAddress,
                    Email = reqDTO.Email,
                    Phone = reqDTO.Phone,
                    Website = reqDTO.Website,
                    Category = reqDTO.Category,
                    SubCategory = reqDTO.SubCategory,
                    ContactPerson = reqDTO.ContactPerson,
                    CType = reqDTO.CType,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(CompanyMasterDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started Company Master Delete {reqDTO.CompanyId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_CompanyMaster_Delete, new
                {
                    CompanyId = reqDTO.CompanyId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
            //return Task.CompletedTask;
        }
        public async Task<CompanyMasterDTO> ReadById(CompanyMasterReadByIdRequestDTO reqDTO)
        {

            CompanyMasterDTO retObj = null;
            _logger.LogInformation($"Started Company Master ReadById {reqDTO.CompanyId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<CompanyMasterDTO>(SP_CompanyMaster_ReadById, new
                {
                    CompanyId = reqDTO.CompanyId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<CompanyMasterList> ReadAll()
        {

            CompanyMasterList retObj = new CompanyMasterList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<CompanyMasterDTO>(SP_CompanyMaster_ReadAll, new
                {

                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
    }
}
