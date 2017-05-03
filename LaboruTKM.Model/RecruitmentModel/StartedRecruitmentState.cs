using LaboruTKM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Model.RecruitmentModel
{
    public class StartedRecruitmentState : RecruitmentState
    {
        public override RecruitmentProcessDTO Execute(RecruitmentProcessDTO process, string comments)
        {
            return process;
        }
    }
}
