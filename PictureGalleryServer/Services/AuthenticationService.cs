using Contract;
using Model;
using PictureGalleryServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryServer
{
    public class AuthenticationService : IAuthenticationService
    {
        private static string secretKey = "f002c204c@f6(bb942765#826bDfe68affe80!08d6e714cGfb8bf1cd3b20d92c";
        private DatabaseService _dbService;

        public AuthenticationService(DatabaseService databaseService)
        {
            _dbService = databaseService;
        }

        public string Login(LoginModel login)
        {
            RegisterModel user = _dbService.GetRegisterByUsername(login.Username);
            if(user == null)
            {
                return "LoginError";
            }

            if(!MatchPassword(login.Password, user.Password))
            {
                return "LoginError";
            }

            return user.Token;
        }

        public bool Register(RegisterModel register)
        {
            if(!register.Username.Trim().Equals("") || !register.Password.Trim().Equals(""))
            {
                return false;
            }

            User user = new User();
            user.Username = register.Username;
            user.Name = register.Name;
            user.Lastname = register.Lastname;


            register.Token = GenerateToken();

            using (var context = new Context())
            {
                _dbService.AddRegister(register);
                _dbService.AddUser(user);
            }

            return true;
        }

        public static bool MatchPassword(string newPassword, string hashedPassword)
        {
            if (hashedPassword.Equals(MakeHash(newPassword))){
                return true;
            }

            return false;
        }

        private static string MakeHash(string password)
        {
            var encoding = new System.Text.UTF8Encoding();
            var keyBytes = encoding.GetBytes(secretKey);
            var messageBytes = encoding.GetBytes(password);
            using (var hmacsha1 = new HMACSHA1(keyBytes))
            {
                var hashMessage = hmacsha1.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashMessage);
            }
        }

        private static string GenerateToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
