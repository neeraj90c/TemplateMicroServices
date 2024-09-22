using Common.Service;
using Microsoft.Extensions.Options;
using ItemPrice.Interface;
using System.Data.SqlClient;
using System.Data;
using ItemPrice.DTO;
using Dapper;


namespace ItemPrice.Service
{
    public class ItemPriceService : DABase, IItemPrice
    {
        private const string SP_ItemPrice_Create = "ItemPrice_Create";
        private const string SP_ItemPrice_Delete = "ItemPrice_Delete";
        private const string SP_ItemPrice_ReadAll = "ItemPrice_ReadAll";
        private const string SP_ItemPrice_ReadById = "ItemPrice_ReadById";
        private const string SP_ItemPrice_ReadByItemId = "ItemPrice_ReadByItemId";
        private const string SP_ItemPrice_Update = "ItemPrice_Update";
        private ILogger<ItemPriceService> _logger;
        public ItemPriceService(IOptions<ConnectionSettings> connectionSettings, ILogger<ItemPriceService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<ItemPriceDTO> Create(ItemPriceCreateRequestDTO reqDTO)
        {

            ItemPriceDTO retObj = null;
            _logger.LogInformation($"Started Item Price Create {reqDTO.MRP}  for CP: {reqDTO.CP}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<ItemPriceDTO>(SP_ItemPrice_Create, new
                {
                    ItemId = reqDTO.ItemId,
                    MRP = reqDTO.MRP,
                    IP1 = reqDTO.IP1,
                    IP2 = reqDTO.IP2,
                    IP3 = reqDTO.IP3,
                    CP = reqDTO.CP,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<ItemPriceDTO> Update(ItemPriceUpdateRequestDTO reqDTO)
        {

            ItemPriceDTO retObj = null;
            _logger.LogInformation($"Started Item Price Update {reqDTO.PriceId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<ItemPriceDTO>(SP_ItemPrice_Update, new
                {
                    PriceId = reqDTO.PriceId,
                    ItemId = reqDTO.ItemId,
                    MRP = reqDTO.MRP,
                    IP1 = reqDTO.IP1,
                    IP2 = reqDTO.IP2,
                    IP3 = reqDTO.IP3,
                    CP = reqDTO.CP,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(ItemPriceDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started Item Price Delete {reqDTO.PriceId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_ItemPrice_Delete, new
                {
                    PriceId = reqDTO.PriceId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
            //return Task.CompletedTask;
        }
        public async Task<ItemPriceDTO> ReadById(ItemPriceReadByIdRequestDTO reqDTO)
        {

            ItemPriceDTO retObj = null;
            _logger.LogInformation($"Started Item Price ReadById {reqDTO.PriceId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<ItemPriceDTO>(SP_ItemPrice_ReadById, new
                {
                    PriceId = reqDTO.PriceId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

        public async Task<ItemPriceDTO> ReadByItemId(ItemPriceReadByItemIdRequestDTO reqDTO)
        {

            ItemPriceDTO retObj = null;
            _logger.LogInformation($"Started Item Price ReadById {reqDTO.ItemId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<ItemPriceDTO>(SP_ItemPrice_ReadByItemId, new
                {
                    ItemId = reqDTO.ItemId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

        public async Task<ItemPriceList> ReadAll()
        {

            ItemPriceList retObj = new ItemPriceList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<ItemPriceDTO>(SP_ItemPrice_ReadAll, new
                {

                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

    }
}
