using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LaboruTKM.Common
{
    [Table("Answer")]
    public class AnswerTO
    {
        [Key]
        public int AnswerId { get; set; }

        public string Text { get; set; }

        [Required]
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public QuestionTO Question { get; set; }
    }
}
