using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Common
{
    [Table("section")]
    public class SectionDTO
    {
        [Key]
        public int SectionId { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public double EstimatedDuration { get; set; }
        public string Type { get; set; }

        public ICollection<EvaluationDTO> Evaluations { get; set; }

        [NotMapped]
        public List<QuestionTO> Questions { get; set; }
    }
}
