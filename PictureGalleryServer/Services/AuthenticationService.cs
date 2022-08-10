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
    public class AuthenticationService : IAutenticationAndAuthorization
    {
        private static string secretKey = "f002c204c@f6(bb942765#826bDfe68affe80!08d6e714cGfb8bf1cd3b20d92c";
        private DatabaseService _dbService;

        public AuthenticationService()
        {
            _dbService = new DatabaseService(new Context());
        }


        public string Login(LoginModel login)
        {
            try
            {
                RegisterModel user = _dbService.GetRegisterByUsername(login.Username);
                if (user == null)
                {
                    return "";
                }

                if (!MatchPassword(login.Password, user.Password))
                {
                    return "";
                }

                return user.Token;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
           
        }

        public RegisterModel Register(RegisterModel register)
        {
            try
            {
                if (register.Username.Trim().Equals("") || register.Password.Trim().Equals(""))
                {
                    return null;
                }

                User user = new User();
                user.Username = register.Username;
                user.Name = register.Name;
                user.Lastname = register.Lastname;


                register.Token = GenerateToken();
                register.Password = MakeHash(register.Password);

                _dbService.AddUser(user);

                return register;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool IsAuthenticated(string token)
        {
            try
            {
                _dbService.IsAuthenticated(token);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool MatchPassword(string newPassword, string hashedPassword)
        {
            try
            {
                if (hashedPassword.Equals(MakeHash(newPassword)))
                {
                    return true;
                }

                return false;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
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

        public bool IsAuthorized(List<Roles> roles, string token)
        {
            try
            {
                _dbService.IsAuthorized(roles, token);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool RegisterUser(RegisterModel register)
        {
            try
            {
                RegisterModel model = Register(register);
                model.Role = Roles.User;
                _dbService.AddRegister(model);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }

        public bool RegisterAdmin(RegisterModel register)
        {
            try
            {
                RegisterModel model = Register(register);
                model.Role = Roles.Admin;
                _dbService.AddRegister(model);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
