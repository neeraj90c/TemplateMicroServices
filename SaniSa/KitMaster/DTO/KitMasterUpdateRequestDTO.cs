namespace KitMaster.DTO
{
    public class KitMasterUpdateRequestDTO
    {
        public int KitId { get; set; }
        public string? KCode { get; set; }
        public string? KName { get; set; }
        public string? KDescription { get; set; }
        public int IsActive { get; set; }
        public string? ActionUser { get; set; }
    }
}
