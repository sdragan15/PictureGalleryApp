using Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryServer.Services
{
    public class AlbumDbService : IAlbumDbService
    {
        private Context _context;

        public AlbumDbService(Context context)
        {
            _context = context;
        }

        public bool AddPicture(PictureModelDto picture)
        {
            AlbumModelDto album = _context.Albums.FirstOrDefault(x => x.Id == picture.AlbumId);
            if (album == null)
            {
                return false;
            }

            album.Pictures.Add(picture);
            _context.SaveChanges();
            return true;
        }

        public bool CreateAlbum(AlbumModelDto album)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAlbum(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeletePicture(int id)
        {
            throw new NotImplementedException();
        }

        public AlbumModelDto GetAlbum(int id)
        {
            throw new NotImplementedException();
        }

        public List<AlbumModelDto> GetAllAlbums()
        {
            return _context.Albums.ToList();
        }

        public List<PictureModelDto> GetAllPicturesForAlbum(int id)
        {
            AlbumModelDto album = _context.Albums.FirstOrDefault(x => x.Id == id);

            if(album == null)
            {
                return null;
            }

            return album.Pictures;
        }

        public PictureModelDto GetPicture(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAlbum(AlbumModelDto album)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePicture(PictureModelDto picture)
        {
            throw new NotImplementedException();
        }
    }
}
