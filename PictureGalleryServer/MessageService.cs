using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryServer
{
    public class MessageService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
