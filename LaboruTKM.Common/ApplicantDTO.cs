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
    [Table("applicant")]
    public class ApplicantDTO
    {
        [Key]
        public int ApplicantId { get; set; }

        [ForeignKey("Person")]
        [Required]
        public int PersonId { get; set; }
        public PersonDTO Person { get; set; }

        [ForeignKey("JobOffer")]
        [Required]
        public int JobOfferId { get; set; }
        public JobOfferDTO JobOffer { get; set; }

        [DefaultValue("CURRENT_TIMESTAMP")]
        public DateTime DateCreated { get; set; }
    }
}
