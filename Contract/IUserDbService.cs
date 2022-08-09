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
        User GetUserByUsername(string username);
        bool AddUser(User model);
        bool UpdateUser(User model);
        bool DeleteUser(User model);
    }
}
