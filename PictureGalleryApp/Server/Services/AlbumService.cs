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
            return new PictureModelDto()
            {
                Id = picture.Id,
                Name = picture.Name,
                Date = picture.Date,
                ImageUrl = picture.Url,
                Rating = picture.Raiting,
                Tags = picture.Tags,
                AlbumId = picture.AlbumId,
            };
        }

        private PictureModel ConvertFromDto(PictureModelDto picture)
        {
            return new PictureModel()
            {
                Id = picture.Id,
                Name = picture.Name,
                Url = picture.ImageUrl,
                Date = picture.Date,
                Tags = picture.Tags,
                AlbumId= picture.AlbumId,
                Raiting = picture.Rating,
            };
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
    }
}
