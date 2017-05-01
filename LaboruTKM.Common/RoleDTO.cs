using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Common
{
    [Table("Role")]
    public class RoleDTO
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string Name { get; set; }

        [DefaultValue("CURRENT_TIMESTAMP")]
        public DateTime DateCreated { get; set; }
    }
}
