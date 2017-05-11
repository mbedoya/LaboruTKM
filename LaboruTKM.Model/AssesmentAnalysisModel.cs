using LaboruTKM.Common.AssesmentAnalysis;
using LaboruTKM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Model
{
    public class AssesmentAnalysisModel
    {
        static EvaluationDB db = new EvaluationDB();

        public static AssesmentAnalysisReportTO GetAssesmentAnalysis(int assesmentID)
        {
            AssesmentAnalysisReportTO analysis = new AssesmentAnalysisReportTO();
            analysis.RoleResult = GetRoleResult(assesmentID);
            analysis.RoleLevels = GetRoleLevels(assesmentID).OrderBy(x => x.Points).ToList();

            return analysis;
        }

        private static AssesmentRoleResultTO GetRoleResult(int assesmentID)
        {
            AssesmentRoleResultTO result = new AssesmentRoleResultTO();
            result.Title = GetAssesmentRoleName(assesmentID);
            result.Points = GetAssesmentPoints(assesmentID);
            result.PossiblePoints = GetAssesmentPossiblePoints(assesmentID);

            return result;
        }

        public static String GetAssesmentRoleName(int assesmentID)
        {
            string name;

            var query =
                (from a in db.Assesments
                 join e in db.Evaluations on a.EvaluationId equals e.Id
                 join r in db.Roles on e.RoleId equals r.RoleId
                 where a.AssesmentId == assesmentID
                 select new { r.Name }).Single();

            name = query.Name;

            return name;
        }

        public static int GetAssesmentPoints(int assesmentID)
        {
            int points = 0;

            var query =
                from q in db.Questions
                join ar in db.AssesmentResponses on q.QuestionId equals ar.QuestionId
                join s in db.Sections on q.SectionId equals s.SectionId
                where ar.AssesmentID == assesmentID && ar.AnswerIsRight
                select new { q.Points };

            points = query.Sum(q => q.Points);

            return points;
        }

        public static List<AssesmentCandidateTO> GetAssesmentCandidates(int assesmentID)
        {
            List<AssesmentCandidateTO> candidates = new List<AssesmentCandidateTO>();


            /*
            string execCommand =
                string.Format("SELECT a.ID, a.PersonName, IFNULL(SUM(Points), 0)  as Points " +
                " FROM question q " +
                " JOIN assesment_response ar on q.id = ar.questionid " +
                " JOIN assesment a on ar.AssesmentID = a.ID " +
                " WHERE ar.answerisright = 1 AND a.EvaluationID = (SELECT EvaluationID FROM assesment WHERE ID = {0})  " +
                " GROUP BY a.ID, a.PersonName ", assesmentID);

            DataTable levelsTable = ExecuteCommand(execCommand);

            if (levelsTable != null && levelsTable.Rows.Count > 0)
            {
                foreach (DataRow item in levelsTable.Rows)
                {
                    candidates.Add(new AssesmentCandidateTO()
                    {
                        AssesmentID = Convert.ToInt32(item["ID"]),
                        Name = Convert.ToString(item["PersonName"]),
                        Points = Convert.ToInt32(item["Points"])
                    });
                }
            }

             */

            return candidates;
        }

        public static int GetAssesmentPossiblePoints(int assesmentID)
        {
            int points = 0;

            var evaluation = 
                (from a in db.Assesments 
                where a.AssesmentId == assesmentID
                select new { a.EvaluationId }).Single();

            var query =
                from q in db.Questions
                join s in db.Sections on q.SectionId equals s.SectionId
                where s.Evaluations.Any(p => p.Id == evaluation.EvaluationId)
                select new { q.Points };

            points = query.Sum(q => q.Points);
 
            return points;
        }

        private static List<AssesmentRoleLevelTO> GetRoleLevels(int assesmentID)
        {
            List<AssesmentRoleLevelTO> levels = new List<AssesmentRoleLevelTO>();

            var role =
                (from e in db.Evaluations
                join a in db.Assesments on e.Id equals a.EvaluationId
                where a.AssesmentId == assesmentID
                select new { e.RoleId }).FirstOrDefault();

            if (role != null)
            {
                levels =
                (from rl in db.AssementRoleLevels
                 where rl.RoleId == role.RoleId
                 select rl).ToList();                
            }           

            return levels;
        }
    }
}
