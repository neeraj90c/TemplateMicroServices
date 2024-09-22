namespace ComboDetail.DTO
{
    public class ComboDetailCreateRequestDTO
    {
        public int ComboId { get; set; }
        public int ItemId { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal Units { get; set; }
        public decimal? TotalAmt { get; set; }
        public string? ActionUser { get; set; }

    }
}
