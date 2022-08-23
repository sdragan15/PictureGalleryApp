using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Model
{
    public class PictureModelDto : DbEntity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Tags { get; set; }
        public double Rating { get; set; }
        public byte[] ImageData { get; set; }
        public int AlbumId { get; set; }

        public PictureModelDto()
        {
            IsDeleted = false;
        }
    }
}
