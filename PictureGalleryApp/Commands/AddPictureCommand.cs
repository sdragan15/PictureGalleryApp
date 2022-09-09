using PictureGalleryApp.Model;
using PictureGalleryApp.Server.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.Commands
{
    public class AddPictureCommand : PictureCommand<PictureModel>
    {
        private PictureModel picture;
        private IAlbumAppService _service;

        public AddPictureCommand(IAlbumAppService albumAppService)
        {
            _service = albumAppService;
        }

        public override async Task Execute()
        {
            picture.Id = await _service.AddPictureToServer(picture);
        }

        public override async Task Redo()
        {
            try
            {
                await _service.RestorePicture(picture.AlbumId, picture.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public override void Set(PictureModel value)
        {
            picture = value;
        }

        public override async Task Undo()
        {
            try
            {
                await _service.DeletePicture(picture.AlbumId, picture.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
