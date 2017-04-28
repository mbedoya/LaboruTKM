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
                (from e in db.Evaluations
                 where e.Id == id
                 select e).FirstOrDefault();

            return evaluation;
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
