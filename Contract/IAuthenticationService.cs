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
        bool RegisterUser(RegisterModelDto register);
        [OperationContract]
        bool RegisterAdmin(RegisterModelDto register);
        [OperationContract]
        string Login(LoginModelDto login);
        [OperationContract]
        bool IsAuthenticated(string token);
        [OperationContract]
        UserModelDto GetUser(string username);
        [OperationContract]
        bool UpdateUser(UserModelDto user);
    }
}
