using Common.DTO;
using Common.Service;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using ValueListItem.Interface;
using ValueListItem.DTO;
using Dapper;

namespace ValueListItem.Service
{
    public class ValueListItemService: DABase, IValueListItem
    {
        private const string SP_ValueListItem_Create = "ValueListItem_Create";
        private const string SP_ValueListItem_Delete = "ValueListItem_Delete";
        private const string SP_ValueListItem_ReadById = "ValueListItem_ReadById";
        private const string SP_ValueListItem_ReadByValueListId = "ValueListItem_ReadByValueListId";
        private const string SP_ValueListItem_ReadByVlCode = "ValueListItem_ReadByVlCode";
        private const string SP_ValueListItem_ReadByVlName = "ValueListItem_ReadByVlName";
        private const string SP_ValueListItem_Update = "ValueListItem_Update";
        APISettings _settings;
        ConnectionSettings _connectionSettings;
        private ILogger<ValueListItemService> _logger;
        public ValueListItemService(IOptions<ConnectionSettings> connectionSettings, ILogger<ValueListItemService> logger, IOptions<APISettings> settings) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
            _settings = settings.Value;
            _connectionSettings = connectionSettings.Value;
        }
        public async Task<ValueListItemDTO> Create(ValueListItemCreateRequestDTO reqDTO)
        {

            ValueListItemDTO retObj = null;
            _logger.LogInformation($"Started Value List Item Create : {reqDTO.VliName}  for Code: {reqDTO.VliCode}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleOrDefaultAsync<ValueListItemDTO>(SP_ValueListItem_Create, new
                {
                    ValuesListId = reqDTO.ValuesListId,
                    VliCode = reqDTO.VliCode,
                    VliName = reqDTO.VliName,
                    VliDesc = reqDTO.VliDesc,
                    DisplaySeq = reqDTO.DisplaySeq,
                    AddField1 = reqDTO.AddField1,
                    AddField2 = reqDTO.AddField2,
                    AddField3 = reqDTO.AddField3,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(ValueListItemDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started Value List Item Delete {reqDTO.ValueListItemId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_ValueListItem_Delete, new
                {
                    ValueListItemId = reqDTO.ValueListItemId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
        }
        public async Task<ValueListItemDTO> Update(ValueListItemUpdateRequestDTO reqDTO)
        {

            ValueListItemDTO retObj = null;
            _logger.LogInformation($"Started Value List Item Update: {reqDTO.ValueListItemId}  for Name: {reqDTO.VliName}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleOrDefaultAsync<ValueListItemDTO>(SP_ValueListItem_Update, new
                {
                    ValueListItemId = reqDTO.ValueListItemId,
                    ValuesListId = reqDTO.ValuesListId,
                    VliCode = reqDTO.VliCode,
                    VliName = reqDTO.VliName,
                    VliDesc = reqDTO.VliDesc,
                    DisplaySeq = reqDTO.DisplaySeq,
                    AddField1 = reqDTO.AddField1,
                    AddField2 = reqDTO.AddField2,
                    AddField3 = reqDTO.AddField3,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<ValueListItemDTO> ReadById(ValueListItemReadByIdRequestDTO reqDTO)
        {

            ValueListItemDTO retObj = null;
            _logger.LogInformation($"Started Value List Item ReadById {reqDTO.ValueListItemId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleOrDefaultAsync<ValueListItemDTO>(SP_ValueListItem_ReadById, new
                {
                    ValueListItemId = reqDTO.ValueListItemId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<ValueListItemList> ReadByValueListId(ValueListItemReadByValueListIdRequestDTO reqDTO)
        {

            ValueListItemList retObj = new ValueListItemList();
            _logger.LogInformation($"Started Value List Item ReadById {reqDTO.ValuesListId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<ValueListItemDTO>(SP_ValueListItem_ReadByValueListId, new
                {
                    ValuesListId = reqDTO.ValuesListId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<ValueListItemList> ReadByVlCode(ValueListItemReadByVlCodeRequestDTO reqDTO)
        {

            ValueListItemList retObj = new ValueListItemList();
            _logger.LogInformation($"Started Value List Item ReadByCode {reqDTO.VlCode}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<ValueListItemDTO>(SP_ValueListItem_ReadByVlCode, new
                {
                    VlCode = reqDTO.VlCode,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<ValueListItemList> ReadByVlName(ValueListItemReadByVlNameRequestDTO reqDTO)
        {

            ValueListItemList retObj = new ValueListItemList();
            _logger.LogInformation($"Started Value List Item ReadByName {reqDTO.VlName}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<ValueListItemDTO>(SP_ValueListItem_ReadByVlName, new
                {
                    VlName = reqDTO.VlName,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
    }
}
