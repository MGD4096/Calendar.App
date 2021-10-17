using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Users;

namespace User.Infrastructure.Domain.Users
{
    public class CalendarRepository : IUserRepository
    {
        private readonly UserContext _userContext;
        public CalendarRepository(UserContext userContext)
        {
            _userContext = userContext;
        }
        public async Task AddAsync(User.Domain.Users.User user)
        {
            await _userContext.User.AddAsync(user);

        }

        public async Task<User.Domain.Users.User> GetByIdAsync(UserId id)
        {
            return await _userContext.User.FindAsync(id);
        }
        public async Task<int> Commit()
        {
            return await _userContext.SaveChangesAsync();
        }
    }
}
