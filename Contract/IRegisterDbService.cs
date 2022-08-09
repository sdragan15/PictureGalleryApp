using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IRegisterDbService
    {
        RegisterModel GetRegisterByUsername(string username);
        bool AddRegister(RegisterModel model);
        bool UpdateRegister(RegisterModel model);
        bool DeleteRegister(RegisterModel model);
    }
}
