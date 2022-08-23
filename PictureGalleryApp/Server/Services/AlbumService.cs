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

        public async Task<List<string>> GetAllAlbumNamesForUser(string username)
        {
            List<string> result = new List<string>();

            Task task = new Task(() =>
            {
                try
                {
                    Connect();
                    result = _proxy.GetAllNamesForUser(username);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

            //task.Start();
            //await task;

            //return result;

            return new List<string> { "hello", "broo", "Wup" };
        }

        private PictureModelDto ConvertToDto(PictureModel picture)
        {
            return new PictureModelDto()
            {
                Id = picture.Id,
                Name = picture.Name,
                Date = picture.Date,
                ImageData = GetBitMap(picture.Url),
                Rating = picture.Raiting,
                Tags = picture.Tags,
                AlbumId = 12,
            };
        }

        private PictureModel ConvertFromDto(PictureModelDto picture)
        {
            return new PictureModel()
            {
                Id = picture.Id,
                Name = picture.Name,
                ImageBit = picture.ImageData,
                Date = picture.Date,
                Tags = picture.Tags,
                AlbumId= picture.AlbumId,
                Raiting = picture.Rating,
                ImageBitmap = (BitmapSource)new ImageSourceConverter().ConvertFrom(picture.ImageData)
            //ImageBitmap = ConvertToBitmapImage(picture.ImageData)
            };
        }

        private BitmapImage ConvertToBitmapImage(byte[] image)
        {
            using (var ms = new System.IO.MemoryStream(image))
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad; // here
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }

        private byte[] GetBitMap(string url)
        {
            byte[] imagebytes;
            using (var webClient = new WebClient())
            {
                imagebytes = webClient.DownloadData(url);
            }

            return Resize2Max50Kbytes(imagebytes);
        }

        private byte[] Resize2Max50Kbytes(byte[] byteImageIn)
        {
            byte[] currentByteImageArray = byteImageIn;
            double scale = 1f;

            MemoryStream inputMemoryStream = new MemoryStream(byteImageIn);
            Image fullsizeImage = Image.FromStream(inputMemoryStream);

            while (currentByteImageArray.Length > 50000)
            {
                Bitmap fullSizeBitmap = new Bitmap(fullsizeImage, new Size((int)(fullsizeImage.Width * scale), (int)(fullsizeImage.Height * scale)));
                MemoryStream resultStream = new MemoryStream();

                fullSizeBitmap.Save(resultStream, fullsizeImage.RawFormat);

                currentByteImageArray = resultStream.ToArray();
                resultStream.Dispose();
                resultStream.Close();

                scale -= 0.05f;
            }

            return currentByteImageArray;
        }

        public void Connect()
        {
            try
            {
                NetTcpBinding netTcpBinding = new NetTcpBinding();
                netTcpBinding.MaxReceivedMessageSize = int.MaxValue;
                netTcpBinding.MaxBufferPoolSize = int.MaxValue;
                netTcpBinding.MaxBufferSize = int.MaxValue;
                ChannelFactory<global::Contract.IAlbumService> channelFactory =
                    new ChannelFactory<global::Contract.IAlbumService>(netTcpBinding, _endpoint);
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
                    foreach(PictureModelDto picture in resultDto)
                    {
                        result.Add(ConvertFromDto(picture));
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


    }
}
