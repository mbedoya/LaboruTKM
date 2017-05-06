using LaboruTKM.Common;
using LaboruTKM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Model.RecruitmentModel
{
    public class RecruitmentProcess
    {
        protected EvaluationDB db = new EvaluationDB();

        RecruitmentState state;

        public RecruitmentProcess()
        {

        }

        public IEnumerable<RecruitmentProcessDTO> GetProcessesByCompany(int companyID)
        {
            var list =
                from p in db.RecruitmentProcesses.Include("Applicant").Include("Applicant.JobOffer.CompanyRole").Include("Applicant.Person")
                where p.Applicant.JobOffer.CompanyRole.CompanyId == companyID
                select p;

            return list;
        }

        public RecruitmentProcessDTO Start(RecruitmentProcessDTO process, string comments)
        {
            state = new UnstartedRecruitmentState();
            return state.Execute(process, comments);
        }

        public RecruitmentProcessDTO Continue(int id, string comments)
        {
            RecruitmentProcessDTO element =
                (from p in db.RecruitmentProcesses
                where p.RecruitmentProcessId == id
                select p).FirstOrDefault();

            if (element != null)
            {
                switch(element.State){
                    case RecruitmentProcessState.Started:
                        state = new StartedRecruitmentState();
                        break;
                }

                element = state.Execute(element, comments);
            }

            return element;
        }

        public List<RecruitmentProcessDTO> GetProcessesByCompanyAndOpening(int companyID, int jobOpening)
        {
            var list =
                (from p in db.RecruitmentProcesses.Include("Applicant").Include("Applicant.Person")
                where p.Applicant.JobOffer.CompanyRole.CompanyId == companyID && p.Applicant.JobOfferId == jobOpening
                select p).ToList();

            return list;
        }
    }
}
