using Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryServer.Services
{
    public class AlbumService : IAlbumService
    {
        private IAlbumDbService _albumDbService;

        public AlbumService()
        {
            _albumDbService = new AlbumDbService(new Context());
        }

        public bool AddPicture(PictureModelDto picture)
        {
            Console.WriteLine("Adding picture...");
            return _albumDbService.AddPicture(picture);
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
            return _albumDbService.GetAllAlbums();
        }

        public List<string> GetAllNamesForUser(string username)
        {
            List<AlbumModelDto> albums = 
                _albumDbService.GetAllAlbums()
                    .Where(x => x.User.Username.Equals(username))
                    .ToList();

            List<string> result = new List<string>();
            foreach(AlbumModelDto album in albums)
            {
                result.Add(album.Name);
            }

            return result;
        }

        public List<PictureModelDto> GetAllPictureForAlbum(int id)
        {
            return _albumDbService.GetAllPicturesForAlbum(id);
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
