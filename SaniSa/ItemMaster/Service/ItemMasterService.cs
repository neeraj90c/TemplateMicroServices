using Common.Service;
using Microsoft.Extensions.Options;
using ItemMaster.Interface;
using System.Data.SqlClient;
using System.Data;
using ItemMaster.DTO;
using Dapper;


namespace ItemMaster.Service
{
    public class ItemMasterService : DABase, IItemMaster
    {
        private const string SP_ItemMaster_Create = "ItemMaster_Create";
        private const string SP_ItemMaster_Delete = "ItemMaster_Delete";
        private const string SP_ItemMaster_ReadAll = "ItemMaster_ReadAll";
        private const string SP_ItemMaster_ReadById = "ItemMaster_ReadById";
        private const string SP_ItemMaster_ReadByKitId = "ItemMaster_ReadByKitId";
        private const string SP_ItemMaster_Update = "ItemMaster_Update";
        private const string SP_ItemMaster_ReadAllPaginated = "ItemMaster_ReadAllPaginated";
        private const string SP_ItemMaster_SearchByName = "ItemMaster_SearchByName";
        private ILogger<ItemMasterService> _logger;
        public ItemMasterService(IOptions<ConnectionSettings> connectionSettings, ILogger<ItemMasterService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<ItemMasterDTO> Create(ItemMasterCreateRequestDTO reqDTO)
        {

            ItemMasterDTO retObj = null;
            _logger.LogInformation($"Started Item Master Create {reqDTO.IName}  for desc: {reqDTO.IDesc}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<ItemMasterDTO>(SP_ItemMaster_Create, new
                {
                    ICode = reqDTO.ICode,
                    IName = reqDTO.IName,
                    IDesc = reqDTO.IDesc,
                    IType = reqDTO.IType,
                    PackingId = reqDTO.PackingId,
                    ISize = reqDTO.ISize,
                    MRPPrinted = reqDTO.MRPPrinted,
                    MOQ = reqDTO.MOQ,
                    BrandId = reqDTO.BrandId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<ItemMasterDTO> Update(ItemMasterUpdateRequestDTO reqDTO)
        {

            ItemMasterDTO retObj = null;
            _logger.LogInformation($"Started Item Master Update {reqDTO.ItemId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<ItemMasterDTO>(SP_ItemMaster_Update, new
                {
                    ItemId = reqDTO.ItemId,
                    ICode = reqDTO.ICode,
                    IName = reqDTO.IName,
                    IDesc = reqDTO.IDesc,
                    IType = reqDTO.IType,
                    PackingId = reqDTO.PackingId,
                    ISize = reqDTO.ISize,
                    MRPPrinted = reqDTO.MRPPrinted,
                    MOQ = reqDTO.MOQ,
                    BrandId = reqDTO.BrandId,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(ItemMasterrDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started Item Master Delete {reqDTO.ItemId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_ItemMaster_Delete, new
                {
                    ItemId = reqDTO.ItemId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
            //return Task.CompletedTask;
        }
        public async Task<ItemMasterDTO> ReadById(ItemMasterReadByIdRequestDTO reqDTO)
        {

            ItemMasterDTO retObj = null;
            _logger.LogInformation($"Started Item Master ReadById {reqDTO.ItemId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<ItemMasterDTO>(SP_ItemMaster_ReadById, new
                {
                    ItemId = reqDTO.ItemId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

        public async Task<ItemMasterList> ReadByKitId(ItemMasterReadByKitIdRequestDTO reqDTO)
        {

            ItemMasterList retObj = new ItemMasterList();
            _logger.LogInformation($"Started Item Master ReadByKitId {reqDTO.KitId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<ItemMasterDTO>(SP_ItemMaster_ReadByKitId, new
                {
                    KitId = reqDTO.KitId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<ItemMasterList> ReadAll()
        {

            ItemMasterList retObj = new ItemMasterList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<ItemMasterDTO>(SP_ItemMaster_ReadAll, new
                {

                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

        public async Task<ItemMasterList> ReadAllPaginated(ItemMasterReadAllPaginatedRequestDTO reqDTO)
        {

            ItemMasterList retObj = new ItemMasterList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<ItemMasterDTO>(SP_ItemMaster_ReadAllPaginated, new
                {
                    PageSize = reqDTO.PageSize,
                    PageNo = reqDTO.PageNo,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

        public async Task<ItemMasterList> SearchByName(ItemMasterSearchByNameRequestDTO reqDTO)
        {

            ItemMasterList retObj = new ItemMasterList();
            _logger.LogInformation($"Started Item Master ReadByKitId {reqDTO.SearchTerm}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<ItemMasterDTO>(SP_ItemMaster_SearchByName, new
                {
                    SearchTerm = reqDTO.SearchTerm,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

    }
}
