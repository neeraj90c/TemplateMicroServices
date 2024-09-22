namespace CategoryDetail.DTO
{
    public class CategoryDetailUpdateRequestDTO
    {
        public int DetailId { get; set; }
        public int CategoryId { get; set; }
        public int ItemId { get; set; }
        public int IsActive { get; set; }
        public string ActionUser { get; set; }
    }
}
