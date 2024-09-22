namespace ValueListItem.DTO
{
    public class ValueListItemCreateRequestDTO
    {
        public int ValuesListId { get; set; }
        public string? VliCode { get; set; }
        public string? VliName { get; set; }
        public string? VliDesc { get; set; }
        public int DisplaySeq { get; set; }
        public string? AddField1 { get; set; }
        public string? AddField2 { get; set; }
        public string? AddField3 { get; set; }
        public string? ActionUser { get; set; }
    }
}
