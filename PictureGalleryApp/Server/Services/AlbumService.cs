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
        private IConverter _converter;

        public AlbumService(IConverter converter)
        {
            _converter = converter;
        }

        public async Task<int> AddPictureToServer(PictureModel picture)
        {
            int id = -1;

            Task task = new Task(() =>
            {
                try
                {
                    Connect();
                    id = _proxy.AddPicture(_converter.ConvertToDto(picture));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            });

            task.Start();
            await task;

            return id;
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
                        result.Add(_converter.ConvertFromDto(album));
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
                            result.Add(_converter.ConvertFromDto(picture));
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
                    _proxy.AddAlbum(_converter.ConvertToDto(album));

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
                        result.Add(_converter.ConvertFromDto(album));
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
                    _proxy.RatePicture(_converter.ConvertToDto(picture));
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
                    result = _converter.ConvertFromDto(resultDto);
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
                    _proxy.UpdatePicture(_converter.ConvertToDto(picture));
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

        public async Task<AlbumModel> GetAlbum(int id)
        {
            AlbumModel album = new AlbumModel();

            Task task = new Task(() =>
            {
                try
                {
                    Connect();
                    var albumDto = _proxy.GetAlbum(id);
                    album = _converter.ConvertFromDto(albumDto);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

            task.Start();
            await task;

            return album;
        }

        public async Task<List<PictureModel>> SearchPictures(string searchText, int albumId)
        {
            List<PictureModel> result = new List<PictureModel>();

            Task task = new Task(() =>
            {
                try
                {
                    Connect();
                    var picturesDto = _proxy.SearchPictures(searchText, albumId);
                    foreach(var picture in picturesDto)
                    {
                        result.Add(_converter.ConvertFromDto(picture));
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

        public async Task<bool> RestorePicture(int albumId, int pictureId)
        {
            bool success = true;

            Task task = new Task(() =>
            {
                try
                {
                    Connect();
                    _proxy.RestorePicture(albumId, pictureId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

            task.Start();
            await task;

            return success;
        }
    }
}
