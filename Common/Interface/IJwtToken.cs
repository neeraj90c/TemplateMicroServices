using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface IJwtToken
    {
        string CreateUserToken(UserSessionDTO users);
        UserSessionDTO ValidateToken(string token);
    }
}
