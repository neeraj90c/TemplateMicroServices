namespace KitDetail.DTO
{
    public class KitDetailUpdateRequestDTO
    {
        public int DetailId { get; set; }
        public int KitId { get; set; }
        public int ItemId { get; set; }
        public string? Remarks { get; set; }
        public int IsActive { get; set; }
        public string? ActionUser { get; set; }
    }
}
