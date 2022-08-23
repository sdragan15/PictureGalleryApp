using PictureGalleryApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.Server.Contract
{
    public interface IAlbumAppService
    {
        Task<List<string>> GetAllAlbumNamesForUser(string username);
        Task<List<PictureModel>> GetAllPicturesForAlbum(int id);
        Task<bool> AddPictureToServer(PictureModel picture);
        void Connect();
    }
}
