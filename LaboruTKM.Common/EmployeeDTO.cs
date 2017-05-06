using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Common
{
    [Table("employee")]
    public class EmployeeDTO
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string Password { get; set; }

        [ForeignKey("Applicant")]
        public int? ApplicantId { get; set; }
        public virtual ApplicantDTO Applicant { get; set; }

        [ForeignKey("Person")]
        public int? PersonId { get; set; }
        public virtual PersonDTO Person { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public CompanyDTO Company { get; set; }

        public ICollection<CompanyRoleDTO> Roles { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
