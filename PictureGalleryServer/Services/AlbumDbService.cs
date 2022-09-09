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

        public void AddAlbum(AlbumModelDto album)
        {
            _context.Albums.Add(album);
            _context.SaveChanges();
        }

        public int AddPicture(PictureModelDto picture)
        {
            AlbumModelDto album = _context.Albums.FirstOrDefault(x => x.Id == picture.AlbumId);
            if (album == null)
            {
                return -1;
            }

            album.Pictures.Add(picture);
            _context.SaveChanges();
            return picture.Id;
        }

        public bool CreateAlbum(AlbumModelDto album)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAlbum(int id)
        {
            AlbumModelDto album = GetAlbum(id);

            foreach (PictureModelDto picture in album.Pictures)
            {
                picture.IsDeleted = true;
            }

            album.IsDeleted = true;
            _context.SaveChanges();

            return true;
        }

        public bool DeletePicture(int albumId, int id)
        {
            if(GetPicture(albumId, id) != null)
            {
                GetPicture(albumId, id).IsDeleted = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public AlbumModelDto GetAlbum(int id)
        {
            return _context.Albums.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }

        public List<AlbumModelDto> GetAllAlbums()
        {
            return _context.Albums.Where(x => x.IsDeleted == false).ToList();
        }

        public List<PictureModelDto> GetAllPicturesForAlbum(int id)
        {
            var pictures = _context.Albums.FirstOrDefault(x => x.Id == id && x.IsDeleted == false).Pictures.Where(x => x.IsDeleted == false).ToList();

            if(pictures == null)
            {
                return null;
            }

            return pictures;
        }

        public PictureModelDto GetPicture(int albumId, int id)
        {
            var album = _context.Albums.FirstOrDefault(x => x.Id == albumId);
            var upPicture = album.Pictures.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
            if (upPicture == null) return null;

            return upPicture;
        }

        private PictureModelDto GetDeletedPicture(int albumId, int id)
        {
            var album = _context.Albums.FirstOrDefault(x => x.Id == albumId);
            var upPicture = album.Pictures.Where(x => x.Id == id).FirstOrDefault();
            if (upPicture == null) return null;

            return upPicture;
        }

        public bool RestorePicture(int albumId, int id)
        {
            var picture = GetDeletedPicture(albumId, id);
            if(picture == null) return false;

            picture.IsDeleted = false;
            _context.SaveChanges();
            return true;
        }

        public bool UpdateAlbum(AlbumModelDto album)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePicture(PictureModelDto picture)
        {
            var upPicture = GetPicture(picture.AlbumId, picture.Id);
            if(upPicture == null)
            {
                return false;
            }

            upPicture.Name = picture.Name;
            upPicture.Tags = picture.Tags;
            upPicture.Rating = picture.Rating;
            upPicture.IsDeleted = picture.IsDeleted;
            upPicture.UserRated = picture.UserRated;
            upPicture.AlbumId = picture.AlbumId;
            upPicture.NumberOfRatings = picture.NumberOfRatings;
            upPicture.ImageUrl = picture.ImageUrl;

            _context.SaveChanges();
            return true;
        }
    }
}
