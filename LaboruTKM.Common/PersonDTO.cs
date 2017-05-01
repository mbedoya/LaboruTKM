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
    [Table("Person")]
    public class PersonDTO
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Summary { get; set; }

        public ICollection<PersonDetailDTO> Skills { get; set; }

        public ICollection<PersonDetailDTO> Education { get; set; }

        public ICollection<PersonDetailDTO> JobExperiences { get; set; }

        [DefaultValue("CURRENT_TIMESTAMP")]
        public DateTime DateCreated { get; set; }
    }
}
