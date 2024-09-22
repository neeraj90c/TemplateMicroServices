using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.DTO
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "User name required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Company Code required.")]
        public string CompanyCode { get; set; }
    }
}
