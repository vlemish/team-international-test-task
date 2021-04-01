using System.Linq;
using TeamInternationalTestEf.EF;
using TeamInternationalTestEf.Models;

namespace TeamInternationalTestEf.Repos
{
    public class FileMessageRepo : GenericRepo<FileMessage>
    {
        public FileMessageRepo()
        {
            _context = new TestDbContext();
            _table = (_context as TestDbContext).FileMessages;
        }

        public FileMessage[] GetAllByUserId(int userId)
        {
            return _table.Where(fm => fm.UserId.Equals(userId)).Select(fm => fm).ToArray();
        }

        public FileMessageManifest[] GetAllFilesManifestByUserId(int userId)
        {
            return _table.Where(fm => fm.UserId.Equals(userId))
                .Select(fm => new FileMessageManifest(fm.Id, fm.CreationTime, fm.UserId, fm.Name, fm.ContentType))
                .ToArray();
        }

        public FileMessage[] GetAllImgsByUserId(int userId)
        {
            return _table.Where(fm => fm.ContentType.Contains("image")).Select(fm => fm).ToArray();
        }
    }
}
