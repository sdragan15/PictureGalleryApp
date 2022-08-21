using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.Server.Contract
{
    public interface IAlbumServer
    {
        List<string> GetAllAlbumNamesForUser(string username);
    }
}
