using System;
using System.Runtime.Serialization;

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
        public string UserRated { get; set; }

        public PictureModelDto()
        {
            IsDeleted = false;
            UserRated = "";
        }
    }
}
