namespace QuotMaster.DTO
{
    public class QuotMasterCreateRequestDTO
    {
        public string? QName { get; set; }
        public string? QCode { get; set; }
        public string? QDesc { get; set; }
        public string? QStatus { get; set; }
        public DateTime? QDate { get; set; }
        public decimal QRange { get; set; }
        public decimal? QMod { get; set; }
        public int ClientId { get; set; }
        public string? ActionUser { get; set; }

    }
}
