using LaboruTKM.Model.SectionData;
using LaboruTKM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaboruTKM.Model
{
    public class Section
    {
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
