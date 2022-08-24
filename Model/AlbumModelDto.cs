using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class AlbumModelDto : DbEntity
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public virtual UserModelDto User { get; set; }
        [DataMember]
        public virtual List<PictureModelDto> Pictures { get; set; }
        [DataMember]
        public bool IsPrivate { get; set; }

        public AlbumModelDto()
        {
            IsDeleted = false;
            Pictures = new List<PictureModelDto>();
        }
    }
}
