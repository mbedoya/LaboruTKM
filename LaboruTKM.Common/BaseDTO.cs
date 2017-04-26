using System;
using System.Collections.Generic;
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

        public DateTime DateCreated { get; set; }
    }
}
