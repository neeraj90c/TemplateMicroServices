using CategoryMaster.Interface;
using Common.Service;
using Microsoft.Extensions.Options;

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
    }

}
