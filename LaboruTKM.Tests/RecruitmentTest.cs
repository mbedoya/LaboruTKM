using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaboruTKM.Common;
using LaboruTKM.Model;
using LaboruTKM.Model.RecruitmentModel;
using System.Collections.Generic;

namespace LaboruTKM.Tests
{
    [TestClass]
    public class RecruitmentTest
    {
        RecruitmentProcess model = new RecruitmentProcess();

        [TestMethod]
        public void Start_JobOfferingIdIsNotSent_JobOpeningNotSentResult()
        {
            JobOfferDTO jobOpening = new JobOfferDTO();
            jobOpening.JobOfferId = 0;

            RecruitmentProcessDTO process = new RecruitmentProcessDTO();
            ApplicantDTO applicant = new ApplicantDTO();
            applicant.JobOffer = jobOpening;

            process.Applicant = applicant;

            string comments = "Tiene los conocimientos que se requieren para el Rol";

            RecruitmentProcessDTO dto = new RecruitmentProcess().Start(process, comments);

            Assert.AreEqual(RecruitmentProcessState.JobOpeningNotSent, dto.State);
        }

        [TestMethod]
        public void Start_PersonDataIncomplete_IncompletePersonDataResult()
        {
            JobOfferDTO jobOpening = new JobOfferDTO();
            jobOpening.JobOfferId = 1;

            PersonDTO person = new PersonDTO();

            RecruitmentProcessDTO process = new RecruitmentProcessDTO();
            ApplicantDTO applicant = new ApplicantDTO();
            applicant.JobOffer = jobOpening;
            applicant.Person = person;

            process.Applicant = applicant;

            string comments = "Tiene los conocimientos que se requieren para el Rol";

            RecruitmentProcessDTO dto = new RecruitmentProcess().Start(process, comments);

            Assert.AreEqual(RecruitmentProcessState.IncompletePersonData, dto.State);
        }

        [TestMethod]
        public void Start_StartRecuitmentProcessWithNewPerson_ProcesStarted()
        {
            JobOfferDTO jobOpening = new JobOfferDTO();
            jobOpening.JobOfferId = 1;

            PersonDTO person = new PersonDTO();
            person.PersonId = 0;
            person.Name = "Juana Galindo";
            person.Email = "juana.galindo@gmail.com";

            RecruitmentProcessDTO process = new RecruitmentProcessDTO();
            ApplicantDTO applicant = new ApplicantDTO();
            applicant.JobOffer = jobOpening;
            applicant.Person = person;

            process.Applicant = applicant;

            string comments = "Tiene los conocimientos que se requieren para el Rol";

            RecruitmentProcessDTO dto = new RecruitmentProcess().Start(process, comments);

            Assert.AreEqual(RecruitmentProcessState.PersonInProcessAlready, dto.State);
        }

        [TestMethod]
        public void Start_ExistingEmail_PersonInProcessAlreadyReturn()
        {
            JobOfferDTO jobOpening = new JobOfferDTO();
            jobOpening.JobOfferId = 1;

            PersonDTO person = new PersonDTO();
            person.Name = "Carlos 2";
            person.Email = "ceospina20@gmail.com";

            RecruitmentProcessDTO process = new RecruitmentProcessDTO();
            ApplicantDTO applicant = new ApplicantDTO();
            applicant.JobOffer = jobOpening;
            applicant.Person = person;

            process.Applicant = applicant;

            string comments = "Tiene los conocimientos que se requieren para el Rol";

            RecruitmentProcessDTO dto = new RecruitmentProcess().Start(process, comments);

            Assert.AreEqual(RecruitmentProcessState.PersonInProcessAlready, dto.State);
        }

        [TestMethod]
        public void Start_ExistingPersonId_PersonInProcessAlreadyReturn()
        {
            JobOfferDTO jobOpening = new JobOfferDTO();
            jobOpening.JobOfferId = 1;

            PersonDTO person = new PersonDTO();
            person.PersonId = 1;

            RecruitmentProcessDTO process = new RecruitmentProcessDTO();
            ApplicantDTO applicant = new ApplicantDTO();
            applicant.JobOffer = jobOpening;
            applicant.Person = person;

            process.Applicant = applicant;

            string comments = "Tiene los conocimientos que se requieren para el Rol";

            RecruitmentProcessDTO dto = new RecruitmentProcess().Start(process, comments);

            Assert.AreEqual(RecruitmentProcessState.PersonInProcessAlready, dto.State);
        }

        [TestMethod]
        public void GetProcessesByCompanyAndOpening_ProcessesExists_ListIsNotNull()
        {
            List<RecruitmentProcessDTO> list = model.GetProcessesByCompanyAndOpening(1, 1);
            Assert.IsTrue(list != null);
        }

        [TestMethod]
        public void GetProcessesByCompanyAndOpening_ProcessesExists_ListhasRows()
        {
            List<RecruitmentProcessDTO> list = model.GetProcessesByCompanyAndOpening(1, 1);
            Assert.IsTrue(list.Count > 0);
        }

    }
}
