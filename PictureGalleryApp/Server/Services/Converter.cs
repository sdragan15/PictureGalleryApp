using Model;
using PictureGalleryApp.Model;
using PictureGalleryApp.Server.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.Server.Services
{
    public class Converter : IConverter
    {
        public PictureModel ConvertFromDto(PictureModelDto picture)
        {
            PictureModel res = new PictureModel()
            {
                Id = picture.Id,
                Name = picture.Name,
                Url = picture.ImageUrl,
                Date = picture.Date,
                Tags = picture.Tags,
                AlbumId = picture.AlbumId,
                UserRated = new List<string>(),
                Raiting = picture.Rating,
                NumberOfRatings = picture.NumberOfRatings,
            };

            if (String.IsNullOrEmpty(picture.UserRated))
            {
                return res;
            }

            var users = picture.UserRated.Split(',');
            foreach (var user in users)
            {
                res.UserRated.Add(user);
            }

            return res;
        }

        public AlbumModel ConvertFromDto(AlbumModelDto album)
        {
            AlbumModel result = new AlbumModel()
            {
                Name = album.Name,
                Id = album.Id,
            };

            return result;
        }

        public SignUpModel ConvertFromDto(UserModelDto user)
        {
            SignUpModel result = new SignUpModel()
            {
                Name = user.Name,
                Lastname = user.Lastname,
                Username = user.Username,
            };

            return result;
        }

        public PictureModelDto ConvertToDto(PictureModel picture)
        {
            PictureModelDto res = new PictureModelDto()
            {
                Id = picture.Id,
                Name = picture.Name,
                Date = picture.Date,
                ImageUrl = picture.Url,
                Rating = picture.Raiting,
                UserRated = "",
                Tags = picture.Tags,
                AlbumId = picture.AlbumId,
                NumberOfRatings = picture.NumberOfRatings,
            };

            foreach (var user in picture.UserRated)
            {
                res.UserRated += ',' + user;
            }

            return res;
        }

        public AlbumModelDto ConvertToDto(AlbumModel album)
        {
            return new AlbumModelDto()
            {
                Name = album.Name,
                IsPrivate = album.IsPrivate,
                User = album.User,
            };
        }

        public UserModelDto ConvertToDto(SignUpModel user)
        {
            return new UserModelDto()
            {
                Username = user.Username,
                Lastname = user.Lastname,
                Name = user.Name
            };
        }
    }
}
