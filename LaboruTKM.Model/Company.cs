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

            return element;
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

            return element;
        }

        public JobOfferDTO AddJobOpening(JobOfferDTO element, int companyID)
        {
            element.CompanyId = companyID;
            element = db.JobOffers.Add(element);

            return element;
        }

        public IEnumerable<JobOfferDTO> GetJobOpenings(int companyID)
        {
            var list =
                from e in db.JobOffers
                where e.CompanyId == companyID
                select e;

            return list;
        }
    }
}
