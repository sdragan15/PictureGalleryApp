using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    [ServiceContract]
    public interface IAuthenticationService
    {
        [OperationContract]
        bool Register(string username, string password);
        [OperationContract]
        bool Login(string username, string password);
    }
}
