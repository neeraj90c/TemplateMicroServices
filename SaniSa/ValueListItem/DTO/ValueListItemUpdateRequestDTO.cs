namespace ValueListItem.DTO
{
    public class ValueListItemUpdateRequestDTO
    {
        public int ValueListItemId { get; set; }
        public int ValuesListId { get; set; }
        public string? VliCode { get; set; }
        public string? VliName { get; set; }
        public string? VliDesc { get; set; }
        public int DisplaySeq { get; set; }
        public string? AddField1 { get; set; }
        public string? AddField2 { get; set; }
        public string? AddField3 { get; set; }
        public int IsActive { get; set; }
        public string? ActionUser { get; set; }
    }
}
