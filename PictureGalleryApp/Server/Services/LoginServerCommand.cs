using Contract;
using Model;
using PictureGalleryApp.Contract;
using PictureGalleryApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.Server.Services
{
    public class LoginServerCommand : IServerCommand
    {
        private string _endpoint;
        private IAuthenticationService proxy;
        private LoginModel _loginModel;

        public LoginServerCommand(string uri, LoginModel loginModel)
        {
            _endpoint = uri;
            _loginModel = loginModel;
        }

        public bool Connect()
        {
            try
            {
                ChannelFactory<IAuthenticationService> channelFactory = new ChannelFactory<IAuthenticationService>(new NetTcpBinding(), _endpoint);
                proxy = channelFactory.CreateChannel();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }

        public bool Execute()
        {
            if (!Connect())
            {
                return false;
            }

            try
            {
                string token = proxy.Login(new LoginModelDto() { Username = "dragan", Password = "dragan" });
                if (token == "")
                {
                    return false;
                }
                Properties.Settings.Default.Token = token;
                Console.WriteLine(token);

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
