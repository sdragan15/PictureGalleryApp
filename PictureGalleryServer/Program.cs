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
            AlbumsServer albumsServer = new AlbumsServer();

            PictureServer pictureServer = new PictureServer();
            AuthenticationServer authenticationServer = new AuthenticationServer();

            Context context = new Context();
            DatabaseService databaseService = new DatabaseService(context);

            albumsServer.Open();
            Console.WriteLine("Albums server is open.");
            authenticationServer.Open();
            Console.WriteLine("Autentication server is open.");
            Console.WriteLine("Server running...");


            Console.WriteLine("\nPress eny key to exit");
            Console.ReadKey();

            albumsServer.Close();
            authenticationServer.Close();
        }
    }
}
