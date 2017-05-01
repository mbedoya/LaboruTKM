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
    [Table("JobOffer")]
    public class JobOfferDTO
    {
        [Key]
        public int JobOfferId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [DefaultValue("CURRENT_TIMESTAMP")]
        public DateTime DateCreated { get; set; }

        [ForeignKey("Company")]
        [Required]
        public int CompanyId { get; set; }
        public CompanyDTO Company { get; set; }

        [ForeignKey("Role")]
        [Required]
        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }
    }
}
