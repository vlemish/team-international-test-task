using System;
using TeamInternationalTestEf.Models.Exceptions;

namespace TeamInternationalTestEf.Models
{
    public class ImageMessage : UserMessage
    {
        private string _contentType;


        public string Name { get; set; }

        public string ContentType
        {
            get
            {
                return _contentType;
            }
            set
            {
                //verify that input is an image, otherwise throw an error.
                bool isCorrectType = value.Contains("image");
                if (isCorrectType)
                    _contentType = value;
                else
                    throw new InvalidContentTypeException($"Type: {value} is a wrong for an image!");
            }
        }

        public byte[] Data { get; set; }


        public ImageMessage()
        {

        }

        public ImageMessage(DateTime creationTime, int userId, byte[] data)
            : base(creationTime, userId)
        {
            Data = data;
        }
    }
}
