using Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryServer.Services
{
    public class AuthDbService : IRegisterDbService, IUserDbService
    {
        private Context _context;

        public AuthDbService(Context context)
        {
            _context = context;
        }

        public AuthDbService()
        {
        }

        public bool AddUser(UserModelDto model)
        {
            try
            {
                if (_context.Users.FirstOrDefault(u => u.Username.Equals(model.Username)) != null)
                {
                    return false;
                }

                _context.Users.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Internal server error");
            }
            
        }

        public bool AddRegister(RegisterModelDto model)
        {
            try
            {
                if (_context.Register.FirstOrDefault(u => u.Username.Equals(model.Username)) != null)
                {
                    return false;
                }

                _context.Register.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Internal server error");
            }
            
        }

        public bool DeleteUser(UserModelDto model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRegister(RegisterModelDto model)
        {
            throw new NotImplementedException();
        }

        public UserModelDto GetUserByUsername(string username)
        {
            try
            {
                return _context.Users.FirstOrDefault(u => u.Username.Equals(username));
            }
            catch(Exception)
            {
                throw new Exception("User dont exist");
            }
            
        }

        public bool UpdateUser(UserModelDto model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRegister(RegisterModelDto model)
        {
            throw new NotImplementedException();
        }

        public RegisterModelDto GetRegisterByUsername(string username)
        {
            try
            {
                return _context.Register.FirstOrDefault(u => u.Username.Equals(username));
            }
            catch (Exception)
            {
                throw new Exception("User dont exist");
            }
            
        }

        public void IsAuthenticated(string token)
        {
            if(_context.Register.FirstOrDefault(u => u.Token.Equals(token)) == null)
            {
                throw new Exception("User is not authenticated!");
            }

        }


        public void IsAuthorized(List<Roles> roles, string token)
        {
            RegisterModelDto model = _context.Register.FirstOrDefault(u => u.Token.Equals(token));

            if (model == null)
            {
                throw new Exception("User with this token doesn't exist");
            }

            if (!roles.Contains(model.Role))
            {
                throw new Exception("User is not authorized!");
            }
        }
    }
}
