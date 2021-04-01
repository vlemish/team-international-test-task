using System;

namespace TeamInternationalTestEf.Models
{
    public class FileMessageManifest
    {
        public int Id { get; set; }

        public DateTime CreationTime { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }


        public FileMessageManifest(int id, DateTime creationTime, int userId, string name, string contentType)
        {
            Id = id;
            CreationTime = creationTime;
            UserId = userId;
            Name = name;
            ContentType = contentType;
        }
    }
}
