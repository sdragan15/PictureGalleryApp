using Model;
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
        Task<List<AlbumModel>> GetAllAlbumsForUser(string username);
        Task<List<PictureModel>> GetAllPicturesForAlbum(int id);
        Task<bool> AddPictureToServer(PictureModel picture);
        Task<bool> AddAlbum(AlbumModel album);
        Task<bool> DeleteAlbum(int id);
        Task<List<AlbumModel>> GetAllPublicAlbums();
        void Connect();
        Task<bool> RatePicture(PictureModel picture);
        Task<PictureModel> GetPicture(int albumId, int id);
        Task<bool> UpdatePicture(PictureModel picture);
        Task<bool> DeletePicture(int albumId, int id);
    }
}
