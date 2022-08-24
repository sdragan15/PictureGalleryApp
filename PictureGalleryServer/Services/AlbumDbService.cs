﻿using Contract;
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
            AlbumModelDto album = GetAlbum(id);

            foreach (PictureModelDto picture in album.Pictures)
            {
                picture.IsDeleted = true;
            }

            album.IsDeleted = true;
            _context.SaveChanges();

            return true;
        }

        public bool DeletePicture(int id)
        {
            throw new NotImplementedException();
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
            AlbumModelDto album = _context.Albums.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);

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
