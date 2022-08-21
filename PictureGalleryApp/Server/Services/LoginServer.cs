using Contract;
using Model;
using PictureGalleryApp.Model;
using PictureGalleryApp.Server.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.Server.Services
{
    public class LoginServer : AuthTemplate
    {
        private LoginModel _loginModel;
        private IAuthenticationService proxy;

        public LoginServer(string url, LoginModel loginModel)
        {
            endpoint = url;
            _loginModel = loginModel;

        }

        protected override void Connect()
        {
            try
            {
                ChannelFactory<IAuthenticationService> channelFactory = new ChannelFactory<IAuthenticationService>(new NetTcpBinding(), endpoint);
                proxy = channelFactory.CreateChannel();
            }
            catch (Exception ex)
            {
                throw (ex);
                
            }
        }


        protected override void Process()
        {
            try
            {
                string token = proxy.Login(new LoginModelDto() { Username = "dragan", Password = "dragan" });
                if (token == "")
                {
                    throw new Exception("Token is not received");
                }
                Properties.Settings.Default.Token = token;
                Console.WriteLine(token);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw (ex);
            }
        }
    }
}
