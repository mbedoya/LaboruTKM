using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Common
{
    public class PersonDetailDTO
    {
        [Key]
        public int PersonDetailId { get; set; }

        [MaxLength(100)]
        public string Text { get; set; }
    }
}
