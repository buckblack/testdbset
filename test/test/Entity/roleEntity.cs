﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test.Entity
{
    [Table("Roles")]
    public class roleEntity
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
