namespace ComboDetail.DTO
{
    public class ComboDetailUpdateRequestDTO
    {
        public int DetailId { get; set; }
        public int ComboId { get; set; }
        public int ItemType { get; set; }
        public int ItemId { get; set; }
        public string? Remarks { get; set; }
        public int IsActive { get; set; }
        public string? ActionUser { get; set; }
    }
}
