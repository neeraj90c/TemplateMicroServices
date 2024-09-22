namespace QuotMaster.DTO
{
    public class QuotMasterUpdateRequestDTO
    {
        public int QuotId { get; set; }
        public string? QName { get; set; }
        public string? QCode { get; set; }
        public string? QDesc { get; set; }
        public DateTime? QDate { get; set; }
        public decimal? QRange { get; set; }
        public decimal? QMod { get; set; }
        public int ClientId { get; set; }
        public string? QStatus { get; set; }
        public int IsActive { get; set; }
        public string? ActionUser { get; set; }
    }
}
