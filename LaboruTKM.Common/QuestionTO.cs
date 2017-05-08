using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LaboruTKM.Common
{
    [Table("Question")]
    public class QuestionTO
    {
        [Key]
        public int QuestionId { get; set; }

        public string Text { get; set; }
        public string Type { get; set; }

        [Required]
        public int Points { get; set; }

        [ForeignKey("Section")]
        public int SectionId { get; set; }
        public SectionDTO Section { get; set; }

        public int? RightAnswerId { get; set; }

        public ICollection<AnswerTO> Answers { get; set; }
    }
}
