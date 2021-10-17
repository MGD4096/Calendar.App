using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Api.Modules.User
{
    public class AddUserRequest
    {
        public string UserName { get; set; }
        public string ForName { get; set; }
        public string SurName { get; set; }
        public string Password { get; set; }
    }
}
