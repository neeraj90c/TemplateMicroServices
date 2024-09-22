using Common.DTO;

namespace ImageMaster.DTO
{
    public class ImageMasterDTO : PaginationDTO
    {
        public int ImageId { get; set; }
        public int MasterId { get; set; }
        public int MasterType { get; set; }
        public string IName { get; set; }
        public string IType { get; set; }
        public string IURL { get; set; }
        public int IsDefault { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class ImageMasterList
    {
        public IEnumerable<ImageMasterDTO> Items { get; set; }
    }
}
