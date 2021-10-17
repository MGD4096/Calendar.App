using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts;

namespace User.Application.Users.CreateUserCommand
{
    public class CreateUserCommand : CommandBase
    {
        public CreateUserCommand(string userName, string forName, string surName, string password)
        {
            UserName = userName;
            ForName = forName;
            SurName = surName;
            Password = password;
        }

        public string UserName { get; set; }
        public string ForName { get; set; }
        public string SurName { get; set; }
        public string Password { get; set; }
        

    }
}
