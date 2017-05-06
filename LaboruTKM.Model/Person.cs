using LaboruTKM.Common;
using LaboruTKM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Model
{
    public class Person
    {
        EvaluationDB db = new EvaluationDB();

        public IEnumerable<PersonDTO> GetAll()
        {
            var list =
                from c in db.People
                select c;

            return list;
        }

        public IEnumerable<PersonDTO> GetVisibleToCompany(int companyID)
        {
            var list =
                from c in db.People
                where !(from a in db.Applicants
                        where a.JobOffer.CompanyRole.CompanyId == companyID
                        select a.PersonId
                        ).Contains(c.PersonId)
                select c;

            return list;
        }

        public PersonDTO Get(int id)
        {
            var element =
                (from c in db.People
                where c.PersonId == id
                select c).FirstOrDefault();

            return element;
        }

        public PersonDTO GetByEmail(string email)
        {
            var element =
                (from c in db.People
                 where c.Email == email
                 select c).FirstOrDefault();

            return element;
        }
    }
}
