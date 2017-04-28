using LaboruTKM.Common;
using LaboruTKM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboruTKM.Model
{
    public class Company
    {
        EvaluationDB db = new EvaluationDB();

        public IEnumerable<CompanyDTO> GetAll()
        {
            var list =
                from c in db.Companies
                orderby c.Id ascending
                select c;

            return list;
        }

        public CompanyDTO Get(int id)
        {
            var element =
                (from e in db.Companies
                 where e.Id == id
                 select e).FirstOrDefault();

            return element;
        }

        public bool Exists(int id)
        {
            return Get(id) != null;
        }

        public void Delete(CompanyDTO element)
        {
            db.Companies.Remove(element);
        }

        public void Update(CompanyDTO element)
        {
            db.Entry(element).CurrentValues.SetValues(element);
        }

        public CompanyDTO Add(CompanyDTO element)
        {
            element = db.Companies.Add(element);

            return element;
        }
    }
}
