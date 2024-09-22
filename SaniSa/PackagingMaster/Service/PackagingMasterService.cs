using Common.Service;
using Microsoft.Extensions.Options;
using PackagingMaster.Interface;
using System.Data.SqlClient;
using System.Data;
using PackagingMaster.DTO;
using Dapper;


namespace PackagingMaster.Service
{
    public class PackagingMasterService : DABase, IPackagingMaster
    {
        private const string SP_PackagingMaster_Create = "PackagingMaster_Create";
        private const string SP_PackagingMaster_Delete = "PackagingMaster_Delete";
        private const string SP_PackagingMaster_ReadAll = "PackagingMaster_ReadAll";
        private const string SP_PackagingMaster_ReadById = "PackagingMaster_ReadById";
        private const string SP_PackagingMaster_Update = "PackagingMaster_Update";
        private const string SP_PackagingMaster_ReadAllPaginated = "PackagingMaster_ReadAllPaginated";
        private ILogger<PackagingMasterService> _logger;
        public PackagingMasterService(IOptions<ConnectionSettings> connectionSettings, ILogger<PackagingMasterService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<PackagingMasterDTO> Create(PackagingMasterCreateRequestDTO reqDTO)
        {

            PackagingMasterDTO retObj = null;
            _logger.LogInformation($"Started Packaging Master Create {reqDTO.PName}  for desc: {reqDTO.PDesc}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<PackagingMasterDTO>(SP_PackagingMaster_Create, new
                {
                    PCode = reqDTO.PCode,
                    PName = reqDTO.PName,
                    PDesc = reqDTO.PDesc,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<PackagingMasterDTO> Update(PackagingMasterUpdateRequestDTO reqDTO)
        {

            PackagingMasterDTO retObj = null;
            _logger.LogInformation($"Started Packaging Master Update {reqDTO.PackagingId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<PackagingMasterDTO>(SP_PackagingMaster_Update, new
                {
                    PackagingId = reqDTO.PackagingId,
                    PCode = reqDTO.PCode,
                    PName = reqDTO.PName,
                    PDesc = reqDTO.PDesc,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(PackagingMasterDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started Packaging Master Delete {reqDTO.PackagingId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_PackagingMaster_Delete, new
                {
                    PackagingId = reqDTO.PackagingId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
            //return Task.CompletedTask;
        }
        public async Task<PackagingMasterDTO> ReadById(PackagingMasterReadByIdRequestDTO reqDTO)
        {

            PackagingMasterDTO retObj = null;
            _logger.LogInformation($"Started Packaging Master ReadById {reqDTO.PackagingId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<PackagingMasterDTO>(SP_PackagingMaster_ReadById, new
                {
                    PackagingId = reqDTO.PackagingId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<PackagingMasterList> ReadAll()
        {

            PackagingMasterList retObj = new PackagingMasterList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<PackagingMasterDTO>(SP_PackagingMaster_ReadAll, new
                {

                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

        public async Task<PackagingMasterList> ReadAllPaginated(PackagingMasterReadAllPaginatedRequestDTO reqDTO)
        {

            PackagingMasterList retObj = new PackagingMasterList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<PackagingMasterDTO>(SP_PackagingMaster_ReadAllPaginated, new
                {
                    PageSize = reqDTO.PageSize,
                    PageNo = reqDTO.PageNo,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

    }
}
