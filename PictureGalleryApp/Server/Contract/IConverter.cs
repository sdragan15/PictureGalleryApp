using Model;
using PictureGalleryApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.Server.Contract
{
    public interface IConverter
    {
        PictureModel ConvertFromDto(PictureModelDto picture);
        PictureModelDto ConvertToDto(PictureModel picture);
        AlbumModel ConvertFromDto(AlbumModelDto album);
        AlbumModelDto ConvertToDto(AlbumModel album);
        SignUpModel ConvertFromDto(UserModelDto user);
        UserModelDto ConvertToDto(SignUpModel user);
    }
}
