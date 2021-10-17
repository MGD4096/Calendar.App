using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.Users
{
    public interface IUserRepository
    {
        Task AddAsync(User user);

        Task<User> GetByIdAsync(UserId id);
        Task<int> Commit();
    }
}
