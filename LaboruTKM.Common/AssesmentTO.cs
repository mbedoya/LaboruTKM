using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LaboruTKM.Common
{
    [Table("assesment")]
    public class AssesmentTO
    {
        [Key]
        public int AssesmentId { get; set; }

        [Index]
        public string AssesmentKey { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public CompanyDTO Company { get; set; }

        [ForeignKey("Evaluation")]
        public int EvaluationId { get; set; }
        public EvaluationDTO Evaluation { get; set; }

        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public EmployeeDTO Employee { get; set; }

        [ForeignKey("Person")]
        public int? PersonId { get; set; }
        public PersonDTO Person { get; set; }

        public DateTime? DateStarted { get; set; }
        public DateTime? DateFinished { get; set; }

        [NotMapped]
        public AssesmentStatus Status { get; set; }

        public AssementType Type { get; set; }
    }

    public enum AssementType
    {
        Candidate,
        Internal
    }

    public enum AssesmentStartOperationState
    {
        Successful,
        AssementNotFound,
        AlreadyStarted
    }

    public enum AssesmentAnswerQuestionResult
    {
        Successful,
        InvalidResponse
    }

    public enum AssesmentStatus
    {
        Created,
        Started,
        Done
    }

    public enum AssesmentEndOperationState
    {
        AssementNotStarted,
        AlreadyDone,
        Successful
    }
}
