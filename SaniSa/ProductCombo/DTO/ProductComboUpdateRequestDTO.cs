namespace ProductCombo.DTO
{
    public class ProductComboUpdateRequestDTO
    {
        public int ComboId { get; set; }
        public string? CCode { get; set; }
        public string? CName { get; set; }
        public string? CDescription { get; set; }
        public string? CreationType { get; set; }
        public int IsActive { get; set; }
        public string? ActionUser { get; set; }
    }
}
