using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Common
{
    [Table("recruitmentprocess")]
    public class RecruitmentProcessDTO
    {
        [Key]
        public int RecruitmentProcessId { get; set; }

        public string Comments { get; set; }

        public RecruitmentProcessState State { get; set; }

        public ApplicantDTO Applicant { get; set; }

        public DateTime DateUpdated { get; set; }

        public ICollection<RecruitmentProcessStepDTO> Steps { get; set; }
    }

    public enum RecruitmentProcessState
    {
        Unstarted = 0,
        Started = 1,
        InvitationSent = 2,
        JobOpeningNotSent = 50,
        IncompletePersonData = 60,
        PersonNotFound = 70,
        PersonInProcessAlready = 80
    }
}
