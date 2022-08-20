using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGalleryServer
{
    public class Context: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RegisterModelDto> Register { get; set; }
    }
}
