using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Authorization
{
    public class AuthorizeUserRequirement : IAuthorizationRequirement
    {
        public int Age { get; private set; }

        public AuthorizeUserRequirement(int age) { Age = age; }
    }
}
