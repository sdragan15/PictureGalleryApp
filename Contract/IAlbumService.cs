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
        bool CreateAlbum(AlbumModelDto album);
        [OperationContract]
        bool UpdateAlbum(AlbumModelDto album);
        [OperationContract]
        bool DeleteAlbum(int id);
        [OperationContract]
        AlbumModelDto GetAlbum(int id);
        [OperationContract]
        List<AlbumModelDto> GetAllAlbums();
        [OperationContract]
        List<AlbumModelDto> GetAllAlbumsForUser(string username);
        [OperationContract]
        bool AddPicture(PictureModelDto picture);
        [OperationContract]
        bool DeletePicture(int id);
        [OperationContract]
        bool UpdatePicture(PictureModelDto picture);
        [OperationContract]
        PictureModelDto GetPicture(int id);
        [OperationContract]
        List<PictureModelDto> GetAllPictureForAlbum(int id);
    }
}
