namespace UserMaster.DTO
{
    public class UserReadAllPaginatedRequestDTO
    {
        public int ProjectId { get; set; }
        public int CompanyId { get; set; }
        public int PageSize { get; set; }
        public int PageNo { get; set; }
    }
}
