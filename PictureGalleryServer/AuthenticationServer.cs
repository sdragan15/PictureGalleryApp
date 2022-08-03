using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryServer
{
    public class AuthenticationServer
    {
        private string endpointName = "Auth";
        private ServiceHost serviceHost;

        public AuthenticationServer()
        {
            string endpoint = String.Format("net.tcp://localhost:10106/{0}", endpointName);
            NetTcpBinding binding = new NetTcpBinding();
            serviceHost = new ServiceHost(typeof(AuthenticationService));
            serviceHost.AddServiceEndpoint(typeof(IAuthenticationService), binding, endpoint);
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
