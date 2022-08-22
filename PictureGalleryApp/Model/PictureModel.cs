using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
