namespace KitDetail.DTO
{
    public class KitDetailCreateRequestDTO
    {
        public int KitId { get; set; }
        public int ItemId { get; set; }
        public string? Remarks { get; set; }
        public string? ActionUser { get; set; }

    }
}
