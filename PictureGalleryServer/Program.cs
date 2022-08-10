using PictureGalleryServer.Services;
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

            Context context = new Context();
            DatabaseService databaseService = new DatabaseService(context);

            pictureServer.Open();
            authenticationServer.Open();

            Console.WriteLine("Server running...");

            Console.ReadKey();

            pictureServer.Close();
            authenticationServer.Close();
        }
    }
}
