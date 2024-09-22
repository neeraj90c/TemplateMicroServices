using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class UserSessionDTO
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Designation { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string RoleId { get; set; }
    }
}
