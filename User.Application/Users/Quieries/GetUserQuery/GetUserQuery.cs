using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Configuration.Queries;

namespace User.Application.Users.GetUserQuery
{
    public class GetUserQuery : QueryBase<UserDto>
    {
        public GetUserQuery(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
