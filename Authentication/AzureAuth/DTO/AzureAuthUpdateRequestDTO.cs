namespace AzureAuth.DTO
{
    public class AzureAuthUpdateRequestDTO
    {
        public int AzureUserId { get; set; }
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AUserId { get; set; }
        public string? AEmailId { get; set; }
        public int IsActive { get; set; }
        public string? ActionUser { get; set; }
    }
}
