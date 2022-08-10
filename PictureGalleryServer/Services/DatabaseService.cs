using Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryServer.Services
{
    public class DatabaseService : IRegisterDbService, IUserDbService
    {
        private Context _context;

        public DatabaseService(Context context)
        {
            _context = context;
        }

        public DatabaseService()
        {
        }

        public bool AddUser(User model)
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

        public bool AddRegister(RegisterModel model)
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

        public bool DeleteUser(User model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRegister(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsername(string username)
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

        public bool UpdateUser(User model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRegister(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        public RegisterModel GetRegisterByUsername(string username)
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
            RegisterModel model = _context.Register.FirstOrDefault(u => u.Token.Equals(token));

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
