using PictureGalleryApp.Model;
using PictureGalleryApp.Server.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryApp.Server.Services
{
    public class PictureService : IPictureService
    {
        public bool AddPictureToServer(PictureModel picture)
        {
            return false;
        }

        private byte[] GetBitMap(string url)
        {
            return null;
        }
    }
}
