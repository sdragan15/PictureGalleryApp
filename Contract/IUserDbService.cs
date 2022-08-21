using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IUserDbService
    {
        UserModelDto GetUserByUsername(string username);
        bool AddUser(UserModelDto model);
        bool UpdateUser(UserModelDto model);
        bool DeleteUser(UserModelDto model);
    }
}
