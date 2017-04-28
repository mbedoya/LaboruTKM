using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Common
{
    [Table("company")]
    public class CompanyDTO : BaseNamedDTO
    {
        [Required]
        public string Logo { get; set; }

        public string ContactName { get; set; }

        [Required]
        public string ContactEmail { get; set; }
    }
}
