using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryServer
{
    public class PictureServer
    {
        private string endpointName = "PictureGallery";
        private ServiceHost serviceHost;

        public PictureServer()
        {
            string endpoint = String.Format("net.tcp://localhost:10105/{0}", endpointName);
            NetTcpBinding binding = new NetTcpBinding();
            serviceHost = new ServiceHost(typeof(MessageService));
            serviceHost.AddServiceEndpoint(typeof(IMessageService), binding, endpoint);
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
