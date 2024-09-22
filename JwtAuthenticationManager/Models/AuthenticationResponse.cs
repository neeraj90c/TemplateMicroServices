using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthenticationManager.Models
{
    public class AuthenticationResponse
    {
        public string? UserNameIntial { get; set; }
        public string? Token { get; set; }
        public int ExpiresIn { get; set; }
        public string? ProfileImage { get; set; }
        public int UserId { get; set; }
        public string? Designation { get; set; }
        public string? EmailId { get; set; }
        public string? MobileNo { get; set; }
        public string? RoleId { get; set; }
    }
}
