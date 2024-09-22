using CategoryMaster.Interface;
using Common.Service;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using CategoryMaster.DTO;
using System.ComponentModel.Design;
using System.Xml.Linq;

namespace CategoryMaster.Service
{
    public class CategoryMasterService : DABase, ICategoryMaster
    {
         private const string SP_CategoryMaster_Create = "CategoryMaster_Create";
         private const string SP_CategoryMaster_ReadAll = "CategoryMaster_ReadAll";
         private const string SP_CategoryMaster_ReadById = "CategoryMaster_ReadById";
         private const string SP_CategoryMaster_Update = "CategoryMaster_Update";
         private const string SP_CategoryMaster_Delete = "CategoryMaster_Delete";

        private ILogger<CategoryMasterService> _logger;

        public CategoryMasterService(IOptions<ConnectionSettings> connectionSettings, ILogger<CategoryMasterService> logger) : base(connectionSettings.Value.AppKeyPath)
    {
        _logger = logger;
    }


        public async Task<CategoryMasterDTO> Create(CategoryMasterCreateRequestDTO reqDTO)
        {

            CategoryMasterDTO retObj = null;
            _logger.LogInformation($"Started Item Master Create {reqDTO.CName}  for desc: {reqDTO.CDesc}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<CategoryMasterDTO>(SP_CategoryMaster_Create, new
                {
                    CCode  = reqDTO.CCode,
                    CName  = reqDTO.CName,
                    CDesc  = reqDTO.CDesc,
                    CompanyId = reqDTO.CompanyId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task<CategoryMasterDTO> Update(CategoryMasterUpdateRequestDTO reqDTO)
        {

            CategoryMasterDTO retObj = null;
            _logger.LogInformation($"Started Item Master Update {reqDTO.CategoryId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<CategoryMasterDTO>(SP_CategoryMaster_Update, new
                {
                    CategoryId = reqDTO.CategoryId,
                    CCode  = reqDTO.CCode,
                    CName  = reqDTO.CName,
                    CDesc  = reqDTO.CDesc,
                    CompanyId = reqDTO.CompanyId,
                    IsActive = reqDTO.IsActive,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
        public async Task Delete(CategoryMasterDeleteRequestDTO reqDTO)
        {

            _logger.LogInformation($"Started Item Master Delete {reqDTO.CategoryId} ");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(SP_CategoryMaster_Delete, new
                {
                    CategoryId = reqDTO.CategoryId,
                    ActionUser = reqDTO.ActionUser,
                }, commandType: CommandType.StoredProcedure);

            }
            //return Task.CompletedTask;
        }
        public async Task<CategoryMasterDTO> ReadById(CategoryMasterReadByIdRequestDTO reqDTO)
        {

            CategoryMasterDTO retObj = null;
            _logger.LogInformation($"Started Item Master ReadById {reqDTO.CategoryId}");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj = await connection.QuerySingleAsync<CategoryMasterDTO>(SP_CategoryMaster_ReadById, new
                {
                    CategoryId = reqDTO.CategoryId,
                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }

        public async Task<CategoryMasterList> ReadAll()
        {

            CategoryMasterList retObj = new CategoryMasterList();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                retObj.Items = await connection.QueryAsync<CategoryMasterDTO>(SP_CategoryMaster_ReadAll, new
                {

                }, commandType: CommandType.StoredProcedure);

            }

            return retObj;
        }
    }

}
