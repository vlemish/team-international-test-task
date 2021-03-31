using System.Linq;
using TeamInternationalTestEf.EF;
using TeamInternationalTestEf.Models;

namespace TeamInternationalTestEf.Repos
{
    public class TextMessageRepo : GenericRepo<TextMessage>
    {
        public TextMessageRepo()
        {
            _context = new TestDbContext();
            _table = (_context as TestDbContext).TextMessages;
        }

        public TextMessage[] GetAllByUserId(int userId)
        {
            return _table.Where(tm => tm.UserId.Equals(userId)).Select(tm => tm).ToArray();
        }
    }
}
