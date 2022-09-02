using Model;
using PictureGalleryApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.Server.Contract
{
    public interface IUserAppService
    {
        void Connect();
        Task<SignUpModel> GetUser(string username);
        Task<bool> UpdateUser(SignUpModel user);
    }
}
