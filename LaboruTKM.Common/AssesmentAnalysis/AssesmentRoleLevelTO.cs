using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LaboruTKM.Common.AssesmentAnalysis
{
    [Table("roleanalysis")]
    public class AssesmentRoleLevelTO
    {
        [Key]
        public int AssesmentRoleLevelId { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
    }
}
