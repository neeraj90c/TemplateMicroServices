using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthenticationManager.Models
{
    public class AuthenticationRequest
    {
        [Required(ErrorMessage = "User name required.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password required.")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Company Code required.")]
        public string? CompanyCode { get; set; }
    }
}
