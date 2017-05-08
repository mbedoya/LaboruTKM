using LaboruTKM.Common;
using LaboruTKM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaboruTKM.Model.SectionData
{
    public class InternalSectionData : SectionDataProvider
    {
        EvaluationDB db = new EvaluationDB();

        public List<QuestionTO> GetQuestionsByID(int id)
        {
            List<QuestionTO> list =
                (from q in db.Questions.Include("Answers").AsNoTracking()
                 where q.SectionId == id
                 select q).ToList();

            return list;
        }

        public List<QuestionResponseTO> GetQuestionsResponsesByID(int id)
        {
            List<QuestionResponseTO> list =
                (from q in db.Questions.AsNoTracking()
                where q.SectionId == id
                select new QuestionResponseTO() { AnswerID = (int)q.RightAnswerId, QuestionID = q.QuestionId }).ToList();

            return list;
        }
    }
}
