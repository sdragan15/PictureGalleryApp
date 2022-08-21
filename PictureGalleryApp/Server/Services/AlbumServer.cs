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
    public class AlbumServer : IAlbumServer
    {
        private string _endpoint = "net.tcp://localhost:10105/Albums";
        private IAlbumService _proxy;

        public List<string> GetAllAlbumNamesForUser(string username)
        {
            try
            {
                Connect();
               return _proxy.GetAllNamesForUser(username);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<string>();
            }
        }

        private void Connect()
        {
            try
            {
                ChannelFactory<IAlbumService> channelFactory =
                    new ChannelFactory<IAlbumService>(new NetTcpBinding(), _endpoint);
                _proxy = channelFactory.CreateChannel();
            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
    }
}
