using Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryServer
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Register(string username, string password)
        {
            User user = new User();
            user.Username = username;
            user.Password = password;

            using(var context = new Context())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            return true;
        }
    }
}
