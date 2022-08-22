using Contract;
using Model;
using PictureGalleryApp.Server.Contract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.Server.Services
{
    public class AlbumService : IAlbumAppService
    {
        private string _endpoint = "net.tcp://localhost:10105/Albums";
        private global::Contract.IAlbumService _proxy;

        public async Task<List<string>> GetAllAlbumNamesForUser(string username)
        {
            List<string> result = new List<string>();

            Task task = new Task(() =>
            {
                try
                {
                    Connect();
                    result = _proxy.GetAllNamesForUser(username);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

            //task.Start();
            //await task;

            //return result;

            return new List<string> { "hello", "broo", "Wup" };
        }

        private void Connect()
        {
            try
            {
                ChannelFactory<global::Contract.IAlbumService> channelFactory =
                    new ChannelFactory<global::Contract.IAlbumService>(new NetTcpBinding(), _endpoint);
                _proxy = channelFactory.CreateChannel();
            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
    }
}
