﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LoginModelDto : DbEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginModelDto()
        {
            IsDeleted = false;
        }
    }
}
