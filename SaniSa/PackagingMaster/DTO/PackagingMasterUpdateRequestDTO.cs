namespace PackagingMaster.DTO
{
    public class PackagingMasterUpdateRequestDTO
    {
        public int PackagingId { get; set; }
        public string? PCode { get; set; }
        public string? PName { get; set; }
        public string? PDesc { get; set; }
        public int IsActive { get; set; }
        public string? ActionUser { get; set; }
    }
}
