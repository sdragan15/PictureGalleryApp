using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.Model
{
    public class LoginModel
    {
        string username;
        string password;


        public LoginModel(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public LoginModel()
        {

        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
