namespace AzureAuth.DTO
{
    public class AzureAuthCreateRequestDTO
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AUserId { get; set; }
        public string? AEmailId { get; set; }
        public string? ActionUser { get; set; }
    }
}
