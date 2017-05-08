using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LaboruTKM.Common
{
    public class AssesmentContextTO
    {
        [Key]
        public int AssesmentContextId { get; set; }

        [ForeignKey("Assesment")]
        public int AssesmentId { get; set; }
        public AssesmentTO Assesment { get; set; }

        public int SectionIndex { get; set; }
        public int QuestionIndex { get; set; }
        public int MinutesLeft { get; set; }

        [NotMapped]
        public List<QuestionTO> CurrentSectionQuestions { get; set; }
    }
}
