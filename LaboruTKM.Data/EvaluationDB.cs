using LaboruTKM.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Data
{
    public class EvaluationDB : DbContext
    {
        public DbSet<EvaluationDTO> Evaluations { get; set; }
        public DbSet<SectionDTO> Sections { get; set; }
        public DbSet<CompanyDTO> Companies { get; set; }
    }
}
