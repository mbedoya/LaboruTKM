﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Common
{
    public class BaseDTO
    {
        [Key]
        public int Id { get; set; }

        [DefaultValue("CURRENT_TIMESTAMP")]
        public DateTime DateCreated { get; set; }
    }
}
