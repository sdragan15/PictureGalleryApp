using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Model
{
    [DataContract]
    public class PictureModelDto : DbEntity
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Tags { get; set; }
        [DataMember]
        public double Rating { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }
        [DataMember]
        public int AlbumId { get; set; }
        [DataMember]
        public int NumberOfRatings { get; set; }
        [DataMember]
        public List<string> UserRated { get; set; }

        public PictureModelDto()
        {
            IsDeleted = false;
        }
    }
}
