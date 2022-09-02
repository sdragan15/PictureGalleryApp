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
    public class UserService : IUserAppService
    {
        private string _endpoint = "net.tcp://localhost:10106/Auth";
        private IAuthenticationService _proxy;
        private IConverter _converter;


        public UserService(IConverter converter)
        {
            _converter = converter;
        }

        public void Connect()
        {
            try
            {
                NetTcpBinding netTcpBinding = new NetTcpBinding();
                ChannelFactory<IAuthenticationService> channelFactory =
                    new ChannelFactory<IAuthenticationService>(netTcpBinding, _endpoint);
                _proxy = channelFactory.CreateChannel();
            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }

        public async Task<SignUpModel> GetUser(string username)
        {
            SignUpModel result = new SignUpModel();
            Task task = new Task(() =>
            {
                try
                {
                    Connect();
                    UserModelDto resultDto = _proxy.GetUser(username);
                    result = _converter.ConvertFromDto(resultDto);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

            task.Start();
            await task;

            return result;
        }

        public async Task<bool> UpdateUser(SignUpModel user)
        {
            bool success = true;

            Task task = new Task(() =>
            {
                try
                {
                    Connect();
                    success = _proxy.UpdateUser(_converter.ConvertToDto(user));

                }
                catch (Exception ex)
                {
                    success = false;
                    Console.WriteLine(ex.Message);
                }
            });

            task.Start();
            await task;

            return success;
        }
    }
}
