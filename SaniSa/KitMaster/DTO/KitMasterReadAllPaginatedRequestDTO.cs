using Common.DTO;

namespace KitMaster.DTO
{
    public class KitMasterReadAllPaginatedRequestDTO : PaginationDTO
    {
        public int PageSize { get; set; }
        public int PageNo { get; set; }
    }
}
