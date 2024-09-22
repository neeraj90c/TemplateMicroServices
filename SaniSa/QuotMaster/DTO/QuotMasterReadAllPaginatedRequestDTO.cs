using Common.DTO;

namespace QuotMaster.DTO
{
    public class QuotMasterReadAllPaginatedRequestDTO : PaginationDTO
    {
        public int PageSize { get; set; }
        public int PageNo { get; set; }
    }
}
