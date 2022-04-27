using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Common.Constants
{
    public class RoleConstants
    {
        public const string Administrator = "Admin";
        public const string User = "User";
    }

    public class RolePolicy
    {
        public const string AdministratorPolicy = "AdminOnly";
        public const string UserPolicy = "UserOnly";
        public const string AdminOrUser= "AdminOrUser";
    }
}
