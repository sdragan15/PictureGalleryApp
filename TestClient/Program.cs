using Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string endpoint = "net.tcp://localhost:10105/Albums";
            ChannelFactory<IAlbumService> factory = new ChannelFactory<IAlbumService>(new NetTcpBinding(), endpoint);
            IAlbumService proxy = factory.CreateChannel();

            string endpointAuth = "net.tcp://localhost:10106/Auth";
            ChannelFactory<IAuthenticationService> factoryAuth = new ChannelFactory<IAuthenticationService>(new NetTcpBinding(), endpointAuth);
            IAuthenticationService proxyAuth = factoryAuth.CreateChannel();

            string username;
            string password;
            string token = "error";

            while (true)
            {
                try
                {
                    Console.WriteLine("1 -> Register Admin");
                    Console.WriteLine("2 -> Register User");
                    Console.WriteLine("3 -> Login");
                    Console.WriteLine("4 -> Get album names");
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("Username: ");
                            username = Console.ReadLine();
                            Console.WriteLine("Password: ");
                            password = Console.ReadLine();
                            proxyAuth.RegisterAdmin(new RegisterModelDto() { Username = username, Password = password });
                            break;
                        case 2:
                            Console.WriteLine("Username: ");
                            username = Console.ReadLine();
                            Console.WriteLine("Password: ");
                            password = Console.ReadLine();
                            proxyAuth.RegisterUser(new RegisterModelDto() { Username = username, Password = password });
                            break;
                        case 3:
                            Console.WriteLine("Username: ");
                            username = Console.ReadLine();
                            Console.WriteLine("Password: ");
                            password = Console.ReadLine();
                            token = proxyAuth.Login(new LoginModelDto() { Username = username, Password = password });

                            break;
                        case 4:
                            List<string> names = proxy.GetAllNamesForUser("slavko");
                            foreach(string name in names)
                            {
                                Console.WriteLine(name);
                            }

                            break;
                        default:
                            return;
                    }

                    Console.WriteLine("Done\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                


            }
        }
    }
}
