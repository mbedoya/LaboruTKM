using LaboruTKM.Model.SectionData;
using LaboruTKM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LaboruTKM.Data;

namespace LaboruTKM.Model
{
    public class Section
    {
        EvaluationDB db = new EvaluationDB();

        public SectionDTO Get(int id)
        {
            SectionDTO section = db.Sections.Find(id);
            section.Questions = GetQuestionsBySection(section);
            return section;
        }

        public List<QuestionTO> GetQuestionsBySection(SectionDTO section)
        {
            SectionDataProvider provider = SectionDataFactory.CreateProvider(section.Type);
            List<QuestionTO> list = provider.GetQuestionsByID(section.SectionId);

            return list;
        }

        public List<QuestionResponseTO> GetResponsesBySection(SectionDTO section)
        {
            SectionDataProvider provider = SectionDataFactory.CreateProvider(section.Type);
            List<QuestionResponseTO> list = provider.GetQuestionsResponsesByID(section.SectionId);

            return list;
        }
        
    }
}
