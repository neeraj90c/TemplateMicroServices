using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthenticationManager.Models
{
    public class UserAccount
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CompanyCode { get; set; }
    }
}
