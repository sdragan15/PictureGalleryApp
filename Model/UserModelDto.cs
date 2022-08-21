using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserModelDto : DbEntity
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }

        public UserModelDto()
        {
            IsDeleted = false;
        }

       
    }
}
