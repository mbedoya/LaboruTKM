using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Common
{
    public class RecruitmentProcessStepDTO : BaseNamedDTO
    {
        public string Comments { get; set; }

        [ForeignKey("RecruitmentProcess")]
        public int RecruitmentProcessId { get; set; }
        public RecruitmentProcessDTO RecruitmentProcess { get; set; }
    }
}
