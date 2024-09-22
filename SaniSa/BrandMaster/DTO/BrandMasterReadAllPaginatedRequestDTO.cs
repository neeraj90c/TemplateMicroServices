using Common.DTO;

namespace BrandMaster.DTO
{
    public class BrandMasterReadAllPaginatedRequestDTO : PaginationDTO
    {
        public int PageSize { get; set; }
        public int PageNo { get; set; }
    }
}
