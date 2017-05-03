using LaboruTKM.Common;
using LaboruTKM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Model.RecruitmentModel
{
    public abstract class RecruitmentState
    {
        protected EvaluationDB db = new EvaluationDB();

        public abstract RecruitmentProcessDTO Execute(RecruitmentProcessDTO process, string comments);

        protected bool PersonEmailInJobOpeningAlready(string email)
        {
            var element =
                (from p in db.Applicants
                 where p.Person.Email == email
                 select p).FirstOrDefault();

            return element != null;
        }

        protected bool PersonEmailExistsAlready(string email)
        {
            var element =
                (from p in db.People
                 where p.Email == email
                 select p).FirstOrDefault();

            return element != null;
        }

        protected bool PersonIdInJobOpeningAlready(int personID, int jobOpening)
        {
            var element =
                (from p in db.Applicants
                 where p.Person.PersonId == personID && p.JobOffer.JobOfferId == jobOpening
                 select p).FirstOrDefault();

            return element != null;
        }
    }
}
