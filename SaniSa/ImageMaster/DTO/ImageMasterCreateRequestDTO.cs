namespace ImageMaster.DTO
{
    public class ImageMasterCreateRequestDTO
    {
        public int MasterId { get; set; }
        public int MasterType { get; set; }
        public string? IName { get; set; }
        public string? IType { get; set; }
        public string? IURL { get; set; }
        public string? ActionUser { get; set; }
        public int IsDefault { get; set; }

    }
}
