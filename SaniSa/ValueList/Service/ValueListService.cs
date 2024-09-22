using Common.DTO;
using Common.Service;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using ValueList.Interface;
using ValueList.DTO;
using Dapper;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace ValueList.Service
{
    public class ValueListService: DABase, IValueList
    {
        private const string SP_ValueList_Create = "ValueList_Create";
        private const string SP_ValueList_Update = "ValueList_Update";
        private const string SP_ValueList_Delete = "ValueList_Delete";
        private const string SP_ValueList_ReadById = "ValueList_ReadById";
        private const string SP_ValueList_ReadAll = "ValueList_ReadAll";
        APISettings _settings;
        ConnectionSettings _connectionSettings;
        private ILogger<ValueListService> _logger;
        public ValueListService(IOptions<ConnectionSettings> connectionSettings, ILogger<ValueListService> logger, IOptions<APISettings> settings) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
            _settings = settings.Value;
            _connectionSettings = connectionSettings.Value;
        }
        public async Task<ValueListDTO> Create(ValueListCreateRequestDTO reqDTO)
        {

            ValueListDTO retObj = null;
            _logger.LogInformation($"Started Value List Create : {reqDTO.VlName}  for Code: {reqDTO.VlCode}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleOrDefaultAsync<ValueListDTO>(SP_ValueList_Create, new
                {
                    VlCode = reqDTO.VlCode,
                    VlName = reqDTO.VlName,
                    VlDesc = reqDTO.VlDesc,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(ValueListDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started Value List Delete {reqDTO.ValueListId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_ValueList_Delete, new
                {
                    ValueListId = reqDTO.ValueListId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
        }
        public async Task<ValueListDTO> Update(ValueListUpdateRequestDTO reqDTO)
        {

            ValueListDTO retObj = null;
            _logger.LogInformation($"Started Value List Update: {reqDTO.ValueListId}  for Name: {reqDTO.VlName}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleOrDefaultAsync<ValueListDTO>(SP_ValueList_Update, new
                {
                    ValueListId = reqDTO.ValueListId,
                    VlCode = reqDTO.VlCode,
                    VlName = reqDTO.VlName,
                    VlDesc = reqDTO.VlDesc,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<ValueListDTO> ReadById(ValueListReadByIdRequestDTO reqDTO)
        {

            ValueListDTO retObj = null;
            _logger.LogInformation($"Started Value List ReadById {reqDTO.ValueListId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleOrDefaultAsync<ValueListDTO>(SP_ValueList_ReadById, new
                {
                    ValueListId = reqDTO.ValueListId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<ValueListList> ReadAll()
        {

            ValueListList retObj = new ValueListList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<ValueListDTO>(SP_ValueList_ReadAll, new
                {

                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
    }
}
