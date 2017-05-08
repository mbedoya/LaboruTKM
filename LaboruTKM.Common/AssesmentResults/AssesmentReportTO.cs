using LaboruTKM.Common.AssesmentAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaboruTKM.Common.AssesmentResults
{
    public class AssesmentReportTO
    {
        public AssesmentTO AssesmentInfo { get; set; }
        public List<SectionReportTO> Sections { get; set; }
        public AssesmentAnalysisReportTO Analysis { get; set; }
    }
}
