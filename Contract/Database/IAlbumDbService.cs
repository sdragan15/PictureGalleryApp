using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IAlbumDbService
    {
        void AddAlbum(AlbumModelDto album);
        bool CreateAlbum(AlbumModelDto album);
        bool UpdateAlbum(AlbumModelDto album);
        bool DeleteAlbum(int id);
        AlbumModelDto GetAlbum(int id);
        List<AlbumModelDto> GetAllAlbums();
        int AddPicture(PictureModelDto picture);
        bool UpdatePicture(PictureModelDto picture);
        bool DeletePicture(int albumId, int id);
        PictureModelDto GetPicture(int albumId, int id);
        List<PictureModelDto> GetAllPicturesForAlbum(int id);
        bool RestorePicture(int albumId, int id);
    }
}
