using Contract;
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

            //while (true)
            //{
            //    Console.WriteLine("1 -> Register");
            //    Console.WriteLine("2 -> Send message");
            //    switch (int.Parse(Console.ReadLine()))
            //    {
            //        case 1:
            //            Console.WriteLine("Username: ");
            //            string username = Console.ReadLine();
            //            Console.WriteLine("Password: ");
            //            string password = Console.ReadLine();
            //            proxyAuth.Register(username, password);
            //            break;
            //        case 2:
            //            Console.WriteLine("Send some text");
            //            string message = Console.ReadLine();
            //            proxy.SendMessage(message);
            //            Console.WriteLine("Message sent\n");

            //            break;
            //        default:
            //            return;
            //    }

            //    Console.WriteLine("Done\n");
                

            //}
        }
    }
}
