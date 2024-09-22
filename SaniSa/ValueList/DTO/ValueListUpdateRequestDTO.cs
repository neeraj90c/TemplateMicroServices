namespace ValueList.DTO
{
    public class ValueListUpdateRequestDTO
    {
        public int ValueListId { get; set; }
        public string VlCode { get; set; }
        public string VlName { get; set; }
        public string? VlDesc { get; set; }
        public int IsActive { get; set; }
        public string? ActionUser { get; set; }
    }
}
