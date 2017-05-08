using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Common
{
    [Table("AssesmentResponse")]
    public class AssesmentResponseTO
    {
        [Key]
        public int AssesmentResponseId { get; set; }

        [ForeignKey("Assesment")]
        public int AssesmentID { get; set; }
        public AssesmentTO Assesment { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public QuestionTO Question { get; set; }

        [ForeignKey("Answer")]
        public int AnswerId { get; set; }
        public AnswerTO Answer { get; set; }

        public bool AnswerIsRight { get; set; }
    }
}
