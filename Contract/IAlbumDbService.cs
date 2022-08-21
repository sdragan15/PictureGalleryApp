using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IAlbumDbService : IPictureDbService
    {
        bool CreateAlbum(AlbumModelDto album);
        bool UpdateAlbum(AlbumModelDto album);
        bool DeleteAlbum(int id);
        AlbumModelDto GetAlbum(int id);
    }
}
