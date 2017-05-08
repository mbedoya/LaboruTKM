using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Common
{
    [Table("evaluation")]
    public class EvaluationDTO : BaseDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }

        public ICollection<SectionDTO> Sections { get; set; }
    }
}
