using CategoryDetail.Interface;
using Common.Service;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using CategoryDetail.DTO;
using Dapper;

namespace CategoryDetail.Service
{
    public class CategoryDetailService : DABase, ICategoryDetail
    {
        private const string SP_CategoryDetail_Create = "CategoryDetail_Create";
        private const string SP_CategoryDetail_Delete = "CategoryDetail_Delete";
        private const string SP_CategoryDetail_ReadAll = "CategoryDetail_ReadAll";
        private const string SP_CategoryDetail_ReadByCategoryId = "CategoryDetail_ReadByCategoryId";
        private const string SP_CategoryDetail_ReadById = "CategoryDetail_ReadById";
        private const string SP_CategoryDetail_Update = "CategoryDetail_Update";
        private const string SP_CategoryDetail_ReadByItemId = "CategoryDetail_ReadByItemId";

        private ILogger<CategoryDetailService> _logger;

        public CategoryDetailService(IOptions<ConnectionSettings> connectionSettings, ILogger<CategoryDetailService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }

   
        public async Task<CategoryDetailDTO> Create(CategoryDetailCreateRequestDTO reqDTO)
        {

            CategoryDetailDTO retObj = null;
            _logger.LogInformation($"Started Category Detail Create {reqDTO.ItemId}  for remarks: {reqDTO.CategoryId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<CategoryDetailDTO>(SP_CategoryDetail_Create, new
                {
                    CategoryId = reqDTO.CategoryId,
                    ItemId  = reqDTO.ItemId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<CategoryDetailDTO> Update(CategoryDetailUpdateRequestDTO reqDTO)
        {

            CategoryDetailDTO retObj = null;
            _logger.LogInformation($"Started Category Detail Update {reqDTO.DetailId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<CategoryDetailDTO>(SP_CategoryDetail_Update, new
                {
                    DetailId = reqDTO.DetailId,
                    CategoryId = reqDTO.CategoryId,
                    ItemId = reqDTO.ItemId,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(CategoryDetailDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started Category Detail Delete {reqDTO.DetailId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_CategoryDetail_Delete, new
                {
                    DetailId = reqDTO.DetailId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
            //return Task.CompletedTask;
        }
        public async Task<CategoryDetailDTO> ReadById(CategoryDetailReadByIdRequestDTO reqDTO)
        {

            CategoryDetailDTO retObj = null;
            _logger.LogInformation($"Started Category Detail ReadById {reqDTO.DetailId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<CategoryDetailDTO>(SP_CategoryDetail_ReadById, new
                {
                    DetailId = reqDTO.DetailId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<CategoryDetailList> ReadByCategoryId(CategoryDetailReadByCategoryIdRequestDTO reqDTO)
        {

            CategoryDetailList retObj = null;
            _logger.LogInformation($"Started Category Detail ReadByCategoryId {reqDTO.CategoryId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<CategoryDetailDTO>(SP_CategoryDetail_ReadByCategoryId, new
                {
                    CategoryId = reqDTO.CategoryId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<CategoryDetailList> ReadAll()
        {

            CategoryDetailList retObj = new CategoryDetailList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<CategoryDetailDTO>(SP_CategoryDetail_ReadAll, new
                {

                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
    }
}
