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
        RegisterModelDto GetRegisterByUsername(string username);
        bool AddRegister(RegisterModelDto model);
        bool UpdateRegister(RegisterModelDto model);
        bool DeleteRegister(RegisterModelDto model);
        void IsAuthenticated(string token);
        void IsAuthorized(List<Roles> roles, string token);
    }
}
