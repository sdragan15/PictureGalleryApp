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
    public class SignUpService : AuthTemplate
    {
        private SignUpModel _signUpModel;
        private IAuthenticationService proxy;

        public SignUpService(string url, SignUpModel loginModel)
        {
            endpoint = url;
            _signUpModel = loginModel;

        }

        protected override void Connect()
        {
            try
            {
                ChannelFactory<IAuthenticationService> channelFactory =
                    new ChannelFactory<IAuthenticationService>(new NetTcpBinding(), endpoint);
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
                bool registered = proxy.RegisterUser(Map(_signUpModel));
                if (!registered)
                {
                    throw new Exception("User is not registered");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw (ex);
            }
        }

        private LoginModelDto Map(LoginModel model)
        {
            LoginModelDto result = new LoginModelDto();

            result.Username = model.Username;
            result.Password = model.Password;

            return result;
        }

        private RegisterModelDto Map(SignUpModel model)
        {
            RegisterModelDto result = new RegisterModelDto();

            result.Username = model.Username;
            result.Password = model.Password;
            result.Lastname = model.Lastname;
            result.Name = model.Name;

            return result;
        }
    }
}
