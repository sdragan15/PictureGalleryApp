using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PictureGalleryApp.Model
{
    public class PictureModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tags { get; set; }
        public double Raiting { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
        public int AlbumId { get; set; }
        public byte[] ImageBit { get; set; }
        public BitmapSource ImageBitmap { get; set; }
    }
}
