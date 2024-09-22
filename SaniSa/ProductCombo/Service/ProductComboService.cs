using Common.Service;
using Microsoft.Extensions.Options;
using ProductCombo.Interface;
using System.Data.SqlClient;
using System.Data;
using ProductCombo.DTO;
using Dapper;


namespace ProductCombo.Service
{
    public class ProductComboService : DABase, IProductCombo
    {
        private const string SP_ProductCombo_Create = "ProductCombo_Create";
        private const string SP_ProductCombo_Delete = "ProductCombo_Delete";
        private const string SP_ProductCombo_ReadAll = "ProductCombo_ReadAll";
        private const string SP_ProductCombo_ReadById = "ProductCombo_ReadById";
        private const string SP_ProductCombo_Update = "ProductCombo_Update";
        private ILogger<ProductComboService> _logger;
        public ProductComboService(IOptions<ConnectionSettings> connectionSettings, ILogger<ProductComboService> logger) : base(connectionSettings.Value.AppKeyPath)
        {
            _logger = logger;
        }
        public async Task<ProductComboDTO> Create(ProductComboCreateRequestDTO reqDTO)
        {

            ProductComboDTO retObj = null;
            _logger.LogInformation($"Started ProductCombo Create {reqDTO.CCode}  for name: {reqDTO.CName}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<ProductComboDTO>(SP_ProductCombo_Create, new
                {
                    CCode = reqDTO.CCode,
                    CName = reqDTO.CName,
                    CDescription = reqDTO.CDescription,
                    CreationType = reqDTO.CreationType,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<ProductComboDTO> Update(ProductComboUpdateRequestDTO reqDTO)
        {

            ProductComboDTO retObj = null;
            _logger.LogInformation($"Started ProductCombo Update {reqDTO.ComboId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<ProductComboDTO>(SP_ProductCombo_Update, new
                {
                    ComboId = reqDTO.ComboId,
                    CCode = reqDTO.CCode,
                    CName = reqDTO.CName,
                    CDescription = reqDTO.CDescription,
                    CreationType = reqDTO.CreationType,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(ProductComboDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started ProductCombo Delete {reqDTO.ComboId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_ProductCombo_Delete, new
                {
                    ComboId = reqDTO.ComboId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
            //return Task.CompletedTask;
        }
        public async Task<ProductComboDTO> ReadById(ProductComboReadByIdRequestDTO reqDTO)
        {

            ProductComboDTO retObj = null;
            _logger.LogInformation($"Started ProductCombo ReadById {reqDTO.ComboId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<ProductComboDTO>(SP_ProductCombo_ReadById, new
                {
                    ComboId = reqDTO.ComboId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<ProductComboList> ReadAll()
        {

            ProductComboList retObj = new ProductComboList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<ProductComboDTO>(SP_ProductCombo_ReadAll, new
                {

                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

    }
}
