using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AlbumModelDto : DbEntity
    {
        public string Name { get; set; }
        public virtual UserModelDto User { get; set; }
        public virtual List<PictureModelDto> Pictures { get; set; }
        public bool IsPrivate { get; set; }

        public AlbumModelDto()
        {
            IsDeleted = false;
            Pictures = new List<PictureModelDto>();
        }
    }
}
