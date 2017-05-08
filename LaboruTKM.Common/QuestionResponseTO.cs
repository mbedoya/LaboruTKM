using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LaboruTKM.Common
{
    public class QuestionResponseTO
    {
        public int QuestionID { get; set; }
        public int AnswerID { get; set; }
    }
}
