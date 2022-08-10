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
            string endpoint = "net.tcp://localhost:10105/PictureGallery";
            ChannelFactory<IMessageService> factory = new ChannelFactory<IMessageService>(new NetTcpBinding(), endpoint);
            IMessageService proxy = factory.CreateChannel();

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
                    Console.WriteLine("4 -> Send message");
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("Username: ");
                            username = Console.ReadLine();
                            Console.WriteLine("Password: ");
                            password = Console.ReadLine();
                            proxyAuth.RegisterAdmin(new RegisterModel() { Username = username, Password = password });
                            break;
                        case 2:
                            Console.WriteLine("Username: ");
                            username = Console.ReadLine();
                            Console.WriteLine("Password: ");
                            password = Console.ReadLine();
                            proxyAuth.RegisterUser(new RegisterModel() { Username = username, Password = password });
                            break;
                        case 3:
                            Console.WriteLine("Username: ");
                            username = Console.ReadLine();
                            Console.WriteLine("Password: ");
                            password = Console.ReadLine();
                            token = proxyAuth.Login(new LoginModel() { Username = username, Password = password });

                            break;
                        case 4:
                            Console.WriteLine("Send some text");
                            string message = Console.ReadLine();
                            proxy.SendMessage(message, token);
                            Console.WriteLine("Message sent\n");

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
