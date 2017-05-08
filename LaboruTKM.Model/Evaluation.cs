using LaboruTKM.Common;
using LaboruTKM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Model
{
    public class Evaluation
    {
        EvaluationDB db = new EvaluationDB();

        private string industry;
        private string role;

        private int id;

        private List<SectionDTO> sections;

        public Evaluation()
        {

        }

        public Evaluation(string industry, string role)
        {
            this.industry = industry;
            this.role = role;

            //sections = FindSections();
        }

        public Evaluation(int id)
        {
            this.id = id;
            EvaluationDTO eval = Get(id);
            sections = eval.Sections.Select(p=>p).ToList();
            //sections = GetDbSections(id);
        }

        public List<SectionDTO> GetSections()
        {
            return sections;
        }

        public IEnumerable<EvaluationDTO> GetAll()
        {
            var evaluations =
                from e in db.Evaluations
                orderby e.Id ascending
                select e;

            return evaluations;
        }

        public EvaluationDTO Get(int id)
        {
            var evaluation =
                (from e in db.Evaluations.Include("Sections").AsNoTracking()
                 where e.Id == id
                 select e).FirstOrDefault();

            return evaluation;
        }

        private List<SectionDTO> GetDbSections(int id)
        {
            List<SectionDTO> sections =
                (from s in db.Sections.AsNoTracking()
                 where s.Evaluations.Any(p => p.Id == id)
                 select new SectionDTO()
                 {
                     SectionId = s.SectionId,
                     Name = s.Name,
                     Description = s.Description,
                     EstimatedDuration = s.EstimatedDuration,
                     Type = s.Type
                 }).ToList();

            return sections;
        }

        public bool Exists(int id)
        {
            return Get(id) != null;
        }

        public void Delete(EvaluationDTO evaluation)
        {
            db.Evaluations.Remove(evaluation);
        }

        public void Update(EvaluationDTO evaluation)
        {
            db.Entry(evaluation).CurrentValues.SetValues(evaluation);
        }

        public EvaluationDTO Add(EvaluationDTO evaluation)
        {
            evaluation = db.Evaluations.Add(evaluation);

            return evaluation;
        }
    }
}
