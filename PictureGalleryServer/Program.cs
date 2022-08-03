using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PictureServer pictureServer = new PictureServer();
            AuthenticationServer authenticationServer = new AuthenticationServer();
            pictureServer.Open();
            authenticationServer.Open();

            Console.WriteLine("Server running...");

            Console.ReadKey();

            pictureServer.Close();
            authenticationServer.Close();
        }
    }
}
