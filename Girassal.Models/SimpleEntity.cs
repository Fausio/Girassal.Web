﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Models
{
    [Table("SimpleEntity")]
    public class SimpleEntity : common
    {
        public string Type { get; set; }
        public int statusCode { get; set; }



    }
}
