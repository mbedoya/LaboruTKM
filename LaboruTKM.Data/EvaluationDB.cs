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
        public DbSet<RoleDTO> Roles { get; set; }
        public DbSet<JobOfferDTO> JobOffers { get; set; }
        public DbSet<PersonDTO> People { get; set; }
        public DbSet<ApplicantDTO> Applicants { get; set; }
        public DbSet<RecruitmentProcessDTO> RecruitmentProcesses { get; set; }
        public DbSet<RecruitmentProcessStepDTO> RecruitmentProcessSteps { get; set; }
        public DbSet<EmployeeDTO> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EvaluationDB>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
