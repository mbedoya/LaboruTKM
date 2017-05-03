using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Common
{
    public class CompanyRecruitmentStatsDTO
    {
        public int JopOpenings { get; set; }
        public int ActiveProcesses { get; set; }
        public int PausedProcesses { get; set; }
        public int AlertProcesses { get; set; }
    }
}
