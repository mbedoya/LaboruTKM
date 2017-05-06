using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Common
{
    [Table("companyrole")]
    public class CompanyRoleDTO
    {
        [Key]
        public int CompanyRoleId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public Senority RoleSenority { get; set; }

        [Required]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public CompanyDTO Company { get; set; }

        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<EmployeeDTO> Employees { get; set; }
    }

    public enum Senority
    {
        Junior = 1,
        Middle = 2,
        Advanced = 3,
        Expert = 4
    }
}
