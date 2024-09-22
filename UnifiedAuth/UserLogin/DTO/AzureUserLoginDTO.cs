using System.ComponentModel.DataAnnotations;

namespace UserLogin.DTO
{
    public class AzureUserLoginDTO
    {
        [Required(ErrorMessage = "User name required.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password required.")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Company Code required.")]
        public string? CompanyCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AzureUserId { get; set; }
        public string? AzureEmailId { get; set; }
        public long ExpiresOn { get; set; }
    }
}
