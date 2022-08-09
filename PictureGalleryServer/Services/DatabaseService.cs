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

        public bool AddUser(User model)
        {
            if(_context.Users.FirstOrDefault(u => u.Username.Equals(model.Username)) != null)
            {
                return false;
            }

            _context.Users.Add(model);
            _context.SaveChanges();
            return true;
        }

        public bool AddRegister(RegisterModel model)
        {
            if (_context.Register.FirstOrDefault(u => u.Username.Equals(model.Username)) != null)
            {
                return false;
            }

            _context.Register.Add(model);
            _context.SaveChanges();
            return true;
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
            return _context.Users.FirstOrDefault(u => u.Username.Equals(username));
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
            return _context.Register.FirstOrDefault(u => u.Username.Equals(username));
        }
    }
}
