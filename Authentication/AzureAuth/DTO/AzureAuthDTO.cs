namespace AzureAuth.DTO
{
    public class AzureAuthDTO
    {
        public int AzureUserId { get; set; }
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AUserId { get; set; }
        public string? AEmailId { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ActionUser { get; set; }
    }
    public class AzureAuthList
    {
        public IEnumerable<AzureAuthDTO> Items { get; set; }
    }
}
