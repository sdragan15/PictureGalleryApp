using Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryServer.Services
{
    public class UserDbService : IUserDbService
    {
        private Context _context;

        public UserDbService(Context context)
        {
            _context = context;
        }

        public bool AddUser(UserModelDto model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(UserModelDto model)
        {
            throw new NotImplementedException();
        }

        public UserModelDto GetUserByUsername(string username)
        {
            UserModelDto user = _context.Users.Where(u => u.Username.Equals(username) && u.IsDeleted == false).FirstOrDefault();
            return user;
        }

        public bool UpdateUser(UserModelDto model)
        {
            var user = _context.Users.Where(u => u.Username == model.Username && u.IsDeleted == false).FirstOrDefault();
            if (user == null) return false;

            user.Name = model.Username;
            user.Lastname = model.Lastname;
            _context.SaveChanges();
            return true;
        }
    }
}
