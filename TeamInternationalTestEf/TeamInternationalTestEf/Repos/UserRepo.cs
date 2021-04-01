using System.Linq;
using TeamInternationalTestEf.EF;
using TeamInternationalTestEf.Models;

namespace TeamInternationalTestEf.Repos
{
    public class UserRepo : GenericRepo<User>
    {
        public UserRepo()
        {
            _context = new TestDbContext();
            _table = (_context as TestDbContext).Users;
        }

        public User GetByUsername(string username)
        {
            return _table.FirstOrDefault(u => u.Username.Equals(username));
        }
    }
}
