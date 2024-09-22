using Common.DTO;

namespace ItemMaster.DTO
{
    public class ItemMasterReadAllPaginatedRequestDTO : PaginationDTO
    {
        public int PageSize { get; set; }
        public int PageNo { get; set; }
    }
}
