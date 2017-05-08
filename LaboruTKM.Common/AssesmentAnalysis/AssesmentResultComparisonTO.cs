using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LaboruTKM.Common.AssesmentResults;

namespace LaboruTKM.Common.AssesmentAnalysis
{
    public class AssesmentResultComparisonTO
    {
        public List<SectionReportTO> SectionsResults { get; set; }
        public AssesmentResultComparisonType Type { get; set; }
    }

    public enum AssesmentResultComparisonType
    {
        Candidates,
        Internal,
        Industry
    }
}
