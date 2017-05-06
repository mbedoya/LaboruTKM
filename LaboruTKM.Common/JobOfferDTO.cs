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

        [ForeignKey("CompanyRole")]
        public int CompanyRoleId { get; set; }
        public CompanyRoleDTO CompanyRole { get; set; }

        public DateTime DateCreated { get; set; }

        [NotMapped]
        public int ActiveApplicants { get; set; }
    }
}
