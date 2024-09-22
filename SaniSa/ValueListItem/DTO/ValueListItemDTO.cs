namespace ValueListItem.DTO
{
    public class ValueListItemDTO
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
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int IsDeleted { get; set; }
        public string? ActionUser { get; set; }
    }
    public class ValueListItemList
    {
        public IEnumerable<ValueListItemDTO> Items { get; set; }
    }
}
