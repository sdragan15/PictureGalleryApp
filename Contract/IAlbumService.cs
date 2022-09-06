using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    [ServiceContract]
    public interface IAlbumService
    {
        [OperationContract]
        void AddAlbum(AlbumModelDto album);
        [OperationContract]
        bool CreateAlbum(AlbumModelDto album);
        [OperationContract]
        bool UpdateAlbum(AlbumModelDto album);
        [OperationContract]
        bool DeleteAlbum(int id);
        [OperationContract]
        AlbumModelDto GetAlbum(int id);
        [OperationContract]
        List<AlbumModelDto> GetAllPublicAlbums();
        [OperationContract]
        List<AlbumModelDto> GetAllAlbumsForUser(string username);
        [OperationContract]
        bool AddPicture(PictureModelDto picture);
        [OperationContract]
        bool DeletePicture(int albumId, int id);
        [OperationContract]
        bool UpdatePicture(PictureModelDto picture);
        [OperationContract]
        PictureModelDto GetPicture(int albumId, int id);
        [OperationContract]
        List<PictureModelDto> GetAllPictureForAlbum(int id);
        [OperationContract]
        void RatePicture(PictureModelDto picture);
        [OperationContract]
        List<PictureModelDto> SearchPictures(string searchText, int albumId);
        [OperationContract]
        bool RestorePicture(int albumId, int pictureId);
    }
}
