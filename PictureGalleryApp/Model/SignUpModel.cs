using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.Model
{
    public class SignUpModel
    {
        string username;
        string password;
        string name;
        string lastname;

        public SignUpModel(string username, string password, string name, string lastname)
        {
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Lastname = lastname;
        }

        public SignUpModel() { }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public string Lastname { get => lastname; set => lastname = value; }
    }
}
