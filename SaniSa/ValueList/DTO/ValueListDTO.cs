using System.Xml.Linq;

namespace ValueList.DTO
{
    public class ValueListDTO
    {
        public int ValueListId { get; set; }
        public string VlCode { get; set; }
        public string VlName { get; set; }
        public string? VlDesc { get; set; }
        public int IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int IsDeleted { get; set; }
        public string? ActionUser { get; set; }
    }
    public class ValueListList
    {
        public IEnumerable<ValueListDTO> Items { get; set; }
    }
}
