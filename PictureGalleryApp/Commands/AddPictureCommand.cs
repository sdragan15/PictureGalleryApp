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
            await _service.AddPictureToServer(picture);
        }

        public override Task Redo()
        {
            throw new NotImplementedException();
        }

        public override void Set(PictureModel value)
        {
            picture = value;
        }

        public override Task Undo()
        {
            throw new NotImplementedException();
        }
    }
}
