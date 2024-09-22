using Common.DTO;

namespace PackagingMaster.DTO
{
    public class PackagingMasterReadAllPaginatedRequestDTO : PaginationDTO
    {
        public int PageSize { get; set; }
        public int PageNo { get; set; }
    }
}
