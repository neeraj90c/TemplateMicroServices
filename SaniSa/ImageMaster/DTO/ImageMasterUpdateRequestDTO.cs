namespace ImageMaster.DTO
{
    public class ImageMasterUpdateRequestDTO
    {
        public int ImageId { get; set; }
        public int MasterId { get; set; }
        public int MasterType { get; set; }
        public string? IName { get; set; }
        public string? IType { get; set; }
        public string? IURL { get; set; }
        public int IsDefault { get; set; }
        public int IsActive { get; set; }
        public string? ActionUser { get; set; }
    }
}
