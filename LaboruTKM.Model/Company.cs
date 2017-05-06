using LaboruTKM.Common;
using LaboruTKM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Model
{
    public class Company
    {
        EvaluationDB db = new EvaluationDB();

        public IEnumerable<CompanyDTO> GetAll()
        {
            var list =
                from c in db.Companies
                orderby c.CompanyId ascending
                select c;

            return list;
        }

        public CompanyDTO Get(int id)
        {
            var element =
                (from e in db.Companies
                 where e.CompanyId == id
                 select e).FirstOrDefault();

            element.RecruitmentStats = GetStats(id);

            return element;
        }

        public IQueryable GetEmployees(int companyID)
        {
            var list =
                from e in db.Employees.Include("Roles")
                 where e.CompanyId == companyID
                 orderby e.Name
                 select new { e.EmployeeId, e.Name, e.Email, e.DateCreated, e.Roles };

            return list;
        }

        public EmployeeDTO GetEmployee(int employeeID, int companyID)
        {
            var element =
                (from e in db.Employees.Include("Roles")
                where e.CompanyId == companyID && e.EmployeeId == employeeID
                orderby e.Name
                select e).FirstOrDefault();

            return element;
        }

        /*
        public IEnumerable<EmployeeDTO> GetEmployees(int companyID)
        {
            var list =
                (from e in db.Employees.Include("Roles")
                 where e.CompanyId == companyID
                 orderby e.Name
                 select e);

            return list;
        }*/

        public CompanyRecruitmentStatsDTO GetStats(int id){
            CompanyRecruitmentStatsDTO stats = new CompanyRecruitmentStatsDTO();
            stats.JopOpenings = GetTotalJobOpenings(id);
            stats.ActiveProcesses = GetTotalActiveProcesses(id);

            return stats;
        }

        public int GetTotalJobOpenings(int companyID)
        {
            int result =
                (from p in db.JobOffers
                 where p.CompanyRole.CompanyId == companyID
                 select p).Count();

            return result;
        }

        public int GetTotalActiveProcesses(int companyID)
        {
            int result =
                (from p in db.Applicants
                 where p.JobOffer.CompanyRole.CompanyId == companyID
                 select p).Count();

            return result;
            
        }

        public bool Exists(int id)
        {
            return Get(id) != null;
        }

        public void Delete(CompanyDTO element)
        {
            db.Companies.Remove(element);
        }

        public void Update(CompanyDTO element)
        {
            db.Entry(element).CurrentValues.SetValues(element);
        }

        public CompanyDTO Add(CompanyDTO element)
        {
            element = db.Companies.Add(element);

            return element;
        }

        public CompanyDTO Login(string email, string password)
        {
            CompanyDTO element =
                (from p in db.Companies
                 where p.ContactEmail == email
                 select p).FirstOrDefault();

            element.RecruitmentStats = GetStats(element.CompanyId);

            return element;
        }

        public JobOfferDTO AddJobOpening(JobOfferDTO element, int companyID)
        {

            element.CompanyRoleId = companyID;
            element = db.JobOffers.Add(element);

            return element;
        }

        public JobOfferDTO GetJobOpening(int id, int companyID)
        {
            var element =
                (from e in db.JobOffers.Include("CompanyRole")
                 where e.CompanyRole.CompanyId == companyID && e.JobOfferId == id
                 select e).FirstOrDefault();

            return element;
        }

        public List<JobOfferDTO> GetJobOpenings(int companyID)
        {
            var list = 
                (from e in db.JobOffers.Include("CompanyRole")
                where e.CompanyRole.CompanyId == companyID
                select e).ToList();

            return list;
        }
    }
}
