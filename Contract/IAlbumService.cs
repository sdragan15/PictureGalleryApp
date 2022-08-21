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
        List<string> GetAllNamesForUser(string username);
    }
}
