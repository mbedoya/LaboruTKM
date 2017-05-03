using LaboruTKM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Model.RecruitmentModel
{
    public class UnstartedRecruitmentState : RecruitmentState
    {
        public override RecruitmentProcessDTO Execute(RecruitmentProcessDTO process, string comments)
        {
            //Invalid Job Offer Id
            if (process.Applicant.JobOffer.JobOfferId <= 0)
            {
                process.State = RecruitmentProcessState.JobOpeningNotSent;
                return process;
            }

            //Incomplete Person Data
            if (
                (process.Applicant.Person.PersonId == 0 && String.IsNullOrEmpty(process.Applicant.Person.Email))
                || 
                ( process.Applicant.Person.PersonId == 0 && !String.IsNullOrEmpty(process.Applicant.Person.Email) && !PersonEmailExistsAlready(process.Applicant.Person.Email) && String.IsNullOrEmpty(process.Applicant.Person.Name))
                || 
                (process.Applicant.Person.PersonId == 0 && String.IsNullOrEmpty(process.Applicant.Person.Email)) &&  String.IsNullOrEmpty(process.Applicant.Person.Name) )
            {
                process.State = RecruitmentProcessState.IncompletePersonData;
                return process;
            }

            //New Person? Then we need to create it
            if (process.Applicant.Person.PersonId == 0 && !PersonEmailExistsAlready(process.Applicant.Person.Email))
            {
                process.Applicant.Person.DateCreated = DateTime.Now;
                process.Applicant.Person.Title = "";
                process.Applicant.Person = db.People.Add(process.Applicant.Person);
                db.SaveChanges();
            }
            else
            {
                //Person Sent? Check that it exists
                if (process.Applicant.Person.PersonId > 0)
                {
                    if (new Person().Get(process.Applicant.Person.PersonId) == null)
                    {
                        process.State = RecruitmentProcessState.PersonNotFound;
                        return process;
                    }
                }

                //Person not sent & Email Sent? Check it exists
                if (process.Applicant.Person.PersonId == 0 && 
                    !String.IsNullOrEmpty(process.Applicant.Person.Email) && PersonEmailExistsAlready(process.Applicant.Person.Email))
                {
                    process.Applicant.Person = new Person().GetByEmail(process.Applicant.Person.Email);
                }

                //Check Person is not not Process already
                if (PersonIdInJobOpeningAlready(process.Applicant.Person.PersonId, process.Applicant.JobOffer.JobOfferId))
                {
                    process.State = RecruitmentProcessState.PersonInProcessAlready;
                    return process;
                }
            }

            ApplicantDTO applicant = new ApplicantDTO();
            applicant.JobOfferId = process.Applicant.JobOffer.JobOfferId;
            applicant.PersonId = process.Applicant.Person.PersonId;
            applicant.DateCreated = DateTime.Now;

            applicant = db.Applicants.Add(applicant);

            db.SaveChanges();

            process.Applicant = applicant;
            process.State = RecruitmentProcessState.Started;
            process.DateUpdated = DateTime.Now;

            process = db.RecruitmentProcesses.Add(process);

            RecruitmentProcessStepDTO step = new RecruitmentProcessStepDTO();
            step.Name = "CandidateCreated";
            step.DateCreated = DateTime.Now;
            step.RecruitmentProcessId = process.RecruitmentProcessId;

            db.RecruitmentProcessSteps.Add(step);

            db.SaveChanges();

            return process;
        }
    }
}
