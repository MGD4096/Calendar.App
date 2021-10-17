using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.Users
{
    public class User
    {
        private User()
        {

        }
        private User(string userName, string forName, string surName, string password)
        {
            UserId = new UserId(Guid.NewGuid());
            UserName = userName;
            ForName = forName;
            SurName = surName;
            Password = password;
        }
        public static User CreateNew(string userName, string forName, string surName, string password)
        {
            return new User(userName, forName, surName, password);
        }

        public UserId UserId { get; set; }
        public string UserName { get; set; }
        public string ForName { get; set; }
        public string SurName { get; set; }
        public string Password { get; set; }
    }
}
