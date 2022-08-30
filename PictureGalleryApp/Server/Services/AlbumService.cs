using Contract;
using Model;
using PictureGalleryApp.Model;
using PictureGalleryApp.Server.Contract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PictureGalleryApp.Server.Services
{
    public class AlbumService : IAlbumAppService
    {
        private string _endpoint = "net.tcp://localhost:10105/Albums";
        private IAlbumService _proxy;

        public async Task<bool> AddPictureToServer(PictureModel picture)
        {
            bool error = false;

            Task task = new Task(() =>
            {
                try
                {
                    Connect();
                    _proxy.AddPicture(ConvertToDto(picture));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            });

            task.Start();
            await task;

            if (error)
            {
                return false;
            }
            return true;
        }

        public async Task<List<AlbumModel>> GetAllAlbumsForUser(string username)
        {
            List<AlbumModel> result = new List<AlbumModel>();
            List<AlbumModelDto> resultDto = new List<AlbumModelDto>();
            Task task = new Task(() =>
            {
                try
                {
                    Connect();
                    resultDto = _proxy.GetAllAlbumsForUser(username);
                    foreach (AlbumModelDto album in resultDto)
                    {
                        result.Add(ConvertFromDto(album));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

            task.Start();
            await task;

            return result;
        }

        private AlbumModel ConvertFromDto(AlbumModelDto album)
        {
            AlbumModel result = new AlbumModel()
            {
                Name = album.Name,
                Id = album.Id,
            };

            return result;
        }

        private PictureModelDto ConvertToDto(PictureModel picture)
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

            foreach(var user in picture.UserRated)
            {
                res.UserRated += ',' + user;
            }

            return res;
        }

        private PictureModel ConvertFromDto(PictureModelDto picture)
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
                NumberOfRatings= picture.NumberOfRatings,
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


        public void Connect()
        {
            try
            {
                NetTcpBinding netTcpBinding = new NetTcpBinding();
                ChannelFactory<IAlbumService> channelFactory =
                    new ChannelFactory<IAlbumService>(netTcpBinding, _endpoint);
                _proxy = channelFactory.CreateChannel();
            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }

        public async Task<List<PictureModel>> GetAllPicturesForAlbum(int id)
        {
            List<PictureModel> result = new List<PictureModel>();

            Task task = new Task(() =>
            {
                try
                {
                    Connect();
                    List<PictureModelDto> resultDto = _proxy.GetAllPictureForAlbum(id);
                    if (resultDto == null || resultDto.Count == 0)
                    {
                        result = new List<PictureModel>();
                    }
                    else
                    {
                        foreach (PictureModelDto picture in resultDto)
                        {
                            result.Add(ConvertFromDto(picture));
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

            task.Start();
            await task;

            return result;
        }

        public async Task<bool> AddAlbum(AlbumModel album)
        {
            bool success = true;

            Task task = new Task(() =>
            {
                try
                {
                    Connect();
                    _proxy.AddAlbum(ConvertToDto(album));

                }
                catch (Exception ex)
                {
                    success = false;
                    Console.WriteLine(ex.Message);
                }
            });

            task.Start();
            await task;

            return success;
        }

        private AlbumModelDto ConvertToDto(AlbumModel album)
        {
            return new AlbumModelDto()
            {
                Name = album.Name,
                IsPrivate = album.IsPrivate,
                User = album.User,
            };
        }

        public async Task<bool> DeleteAlbum(int id)
        {
            bool success = true;

            Task task = new Task(() => {
                try
                {
                    Connect();
                    _proxy.DeleteAlbum(id);

                }
                catch (Exception ex)
                {
                    success = false;
                    Console.WriteLine(ex.Message);
                }
            });

            task.Start();
            await task;
            return success;
        }

        public async Task<List<AlbumModel>> GetAllPublicAlbums()
        {
            List<AlbumModel> result = new List<AlbumModel>();
            List<AlbumModelDto> resultDto = new List<AlbumModelDto>();
            Task task = new Task(() =>
            {
                try
                {
                    Connect();
                    resultDto = _proxy.GetAllPublicAlbums();
                    foreach (AlbumModelDto album in resultDto)
                    {
                        result.Add(ConvertFromDto(album));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

            task.Start();
            await task;

            return result;
        }

        public async Task<bool> RatePicture(PictureModel picture)
        {
            bool success = true;

            Task task = new Task(() =>
            {
                try
                {
                    Connect();
                    _proxy.RatePicture(ConvertToDto(picture));
                }
                catch (Exception ex)
                {
                    success = false;
                    Console.WriteLine(ex.Message);
                }
            });

            task.Start();
            await task;

            return success;
        }

        public async Task<PictureModel> GetPicture(int albumId, int id)
        {
            PictureModel result = new PictureModel();

            Task task = new Task(() =>
            {
                try
                {
                    Connect();
                    PictureModelDto resultDto = _proxy.GetPicture(albumId, id);
                    result = ConvertFromDto(resultDto);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

            task.Start();
            await task;

            return result;
        }

        public async Task<bool> UpdatePicture(PictureModel picture)
        {
            bool success = true;

            Task task = new Task(() =>
            {
                try
                {
                    Connect();
                    _proxy.UpdatePicture(ConvertToDto(picture));
                }
                catch (Exception ex)
                {
                    success = false;
                    Console.WriteLine(ex.Message);
                }
            });

            task.Start();
            await task;

            return success;
        }

        public async Task<bool> DeletePicture(int albumId, int id)
        {
            bool success = true;

            Task task = new Task(() =>
            {
                try
                {
                    Connect();
                    _proxy.DeletePicture(albumId, id);
                }
                catch (Exception ex)
                {
                    success = false;
                    Console.WriteLine(ex.Message);
                }
            });

            task.Start();
            await task;

            return success;
        }
    }
}
