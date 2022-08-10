using Model;
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
        bool RegisterUser(RegisterModel register);
        [OperationContract]
        bool RegisterAdmin(RegisterModel register);
        [OperationContract]
        string Login(LoginModel login);
        [OperationContract]
        bool IsAuthenticated(string token);
    }
}
