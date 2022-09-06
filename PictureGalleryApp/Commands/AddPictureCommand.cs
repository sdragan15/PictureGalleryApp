﻿using PictureGalleryApp.Model;
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

        public override async Task Redo()
        {
            await _service.RestorePicture(picture.AlbumId, picture.Id);
        }

        public override void Set(PictureModel value)
        {
            picture = value;
        }

        public override async Task Undo()
        {
            await _service.DeletePicture(picture.AlbumId, picture.Id);
        }
    }
}
