using JwtAuthenticationManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthenticationManager.Interface
{
    public interface IAuthenticate
    {
        User Authenticate(AuthenticationRequest authenticationRequest);
    }
}
