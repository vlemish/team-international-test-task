using System.Linq;
using TeamInternationalTestEf.EF;
using TeamInternationalTestEf.Models;

namespace TeamInternationalTestEf.Repos
{
    public class ImageMessageRepo : GenericRepo<ImageMessage>
    {
        public ImageMessageRepo()
        {
            _context = new TestDbContext();
            _table = (_context as TestDbContext).ImageMessages;
        }

        public ImageMessage[] GetAllByUserId(int userId)
        {
            return _table.Where(um => um.UserId.Equals(userId)).Select(um => um).ToArray();
        }
    }
}
