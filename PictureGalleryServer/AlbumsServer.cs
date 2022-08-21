using Contract;
using PictureGalleryServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryServer
{
    public class AlbumsServer
    {
        private string endpointName = "Albums";
        private ServiceHost serviceHost;

        public AlbumsServer()
        {
            string endpoint = String.Format("net.tcp://localhost:10105/{0}", endpointName);
            NetTcpBinding binding = new NetTcpBinding();
            serviceHost = new ServiceHost(typeof(AlbumService));
            serviceHost.AddServiceEndpoint(typeof(IAlbumService), binding, endpoint);
        }

        public void Open()
        {
            serviceHost.Open();
        }

        public void Close()
        {
            serviceHost.Close();
        }
    }
}
